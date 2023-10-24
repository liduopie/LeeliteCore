using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Dapper;

using Hangfire.Console;
using Hangfire.Server;

using JinianNet.JNTemplate;

using JsonFlatten;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.MessageCenter.Dtos.MessageDtos;
using Leelite.MessageCenter.Models.MessageAgg;
using Leelite.MessageCenter.Models.MessageTypeAgg;
using Leelite.MessageCenter.Models.PushPlatformAgg;
using Leelite.MessageCenter.Models.PushRecordAgg;
using Leelite.MessageCenter.Repositories;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Npgsql;

using Template = Leelite.MessageCenter.Models.TemplateAgg.Template;

namespace Leelite.MessageCenter.Jobs
{
    /// <summary>
    /// 将消息展开成推送记录
    /// 后台持续执行
    /// </summary>
    public class MessageToPushRecordsJob : IBackgroundJob
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageTypeRepository _messageTypeRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IPushRecordRepository _recordRepository;
        private readonly IPushPlatformRepository _platformRepository;

        private readonly IDictionary<int, MessageType> _messageTypes = new Dictionary<int, MessageType>();
        private readonly List<Template> _templates = new();
        private readonly List<PushPlatform> _platforms = new();

        private readonly IDbConnection _hangfireConn;

        // 休眠时间
        private int _sleepTime = 1000;

        public MessageToPushRecordsJob(
            IConfiguration configuration,
            IMessageRepository messageRepository,
            IMessageTypeRepository messageTypeRepository,
            ITemplateRepository templateRepository,
            IPushRecordRepository recordRepository,
            IPushPlatformRepository platformRepository)
        {
            _messageRepository = messageRepository;
            _messageTypeRepository = messageTypeRepository;
            _templateRepository = templateRepository;
            _recordRepository = recordRepository;
            _platformRepository = platformRepository;

            var connStr = configuration.GetConnectionString("HangfireConnection");
            _hangfireConn = new NpgsqlConnection(connStr);
        }

        public PerformContext Context { get; set; }

        public void Execute(PerformContext context)
        {

            // 如果任务正在运行 结束任务
            if (CheckProcessing(this.GetType().FullName))
            {
                context.WriteLine($"任务正在运行，对出当前任务！");
                return;
            }

            Context = context;

            InitPlatform();
            InitMessageType();
            InitMessageTemplate();

            context.WriteLine($"MessageToPushRecordsJob:已启动！");

            do
            {

                // 获取未处理的Message
                var parameter = new MessageQueryParameter()
                {
                    Pager = new PageParam()
                    {
                        PageSize = 1000
                    },
                    EndCreateTime = DateTime.Now,
                    Expired = false,
                    Delivered = false,
                    Deleted = false,
                    GenerateRecord = false
                };

                try
                {
                    var total = _messageRepository.Count(parameter.SatisfiedBy());

                    var query = new PagingQuery<Message, MessageQueryParameter>(parameter);

                    var messages = _messageRepository.FindPage(query);

                    if (total > 0)
                    {
                        _sleepTime = 1000;

                        context.WriteLine($"等待消息：{total}个，本次处理：{messages.Count}个。");
                    }
                    else
                    {
                        _sleepTime = 10000;
                    }

                    foreach (var msg in messages)
                    {
                        // 根据 message 展开成消息
                        CreatePushRecords(msg);
                    }
                }
                catch (Exception e)
                {
                    context.WriteLine(e);
                }

                // 休眠
                System.Threading.Thread.Sleep(_sleepTime);

            } while (true);
        }

        private void InitPlatform()
        {
            _platforms.AddRange(_platformRepository.Find(c => c.IsEnabled == true).OrderBy(c => c.Priority));

            Context.WriteLine($"初始化平台:{_platforms.Count}！");
        }

        private void InitMessageType()
        {
            var msgTypes = _messageTypeRepository.Find(c => c.IsEnabled);

            foreach (var msgType in msgTypes)
            {
                _messageTypes.Add(msgType.Id, msgType);
            }

            Context.WriteLine($"初始化消息类别:{_messageTypes.Count}！");
        }

        private void InitMessageTemplate()
        {
            _templates.AddRange(_templateRepository.Find());

            Context.WriteLine($"初始化消息模板:{_templates.Count}！");
        }

        /// <summary>
        /// 根据会话生成消息
        /// </summary>
        /// <param name="session"></param>
        private void CreatePushRecords(Message msg)
        {
            if (!_messageTypes.ContainsKey(msg.MessageTypeId)) return;

            var msgType = _messageTypes[msg.MessageTypeId];

            var dbRecords = _recordRepository.Find(c => c.MessageId == msg.Id);

            var newRecords = new List<PushRecord>();

            var validPlatform = (from c in msgType.PushPlatform
                                 join d in _platforms
                                 on c equals d.Code
                                 where d.IsEnabled == true
                                 select d).Distinct().ToList();

            var data = msg.Data;

            // 序列模式
            if (msgType.PushStrategy == PushStrategy.Sequence)
            {
                throw new Exception("未实现顺序模式。");

                //foreach (var platform in validPlatform)
                //{
                //    var record = BuildRecord(platform, msgType, msg, dbRecords);

                //    if (record == null) continue;

                //    record.Remark = msgType.Topic;

                //    if (record.Id == 0)
                //    {
                //        newRecords.Add(record);
                //        break;
                //    }

                //    if (record.State == PushState.Succeed)
                //    {
                //        break;
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //}

                //Context.WriteLine($"顺序模式：{msg.Id}，生成推送{newRecords.Count}个。");
            }

            if (msgType.PushStrategy == PushStrategy.All)
            {
                var completed = 0;

                foreach (var platform in validPlatform)
                {
                    var record = BuildRecord(platform, msgType, msg, dbRecords);

                    if (record == null) continue;

                    record.Remark = msgType.Topic;

                    if (record.Id == 0)
                    {
                        newRecords.Add(record);
                    }
                    else
                    {

                        if (record.State != PushState.Waiting)
                        {
                            completed++;
                        }
                    }
                }

                if (completed == validPlatform.Count)
                {
                    msg.DeliveryState = true;
                }

                msg.GenerateRecord = true;

                _messageRepository.Update(msg);

                Context.WriteLine($"全通道模式：{msg.Id}，生成推送{newRecords.Count}个。");
            }

            _recordRepository.AddRange(newRecords);
        }

        private PushRecord BuildRecord(PushPlatform platform, MessageType type, Message msg, IList<PushRecord> records)
        {
            var currentTemplate = _templates.Where(c => c.PlatformId == platform.Id && c.MessageTypeCode == type.Code).FirstOrDefault();

            if (currentTemplate == null) return null;

            var contentTemplateString = currentTemplate == null ? "" : currentTemplate.ContentTemplate;
            var urlTemplateString = currentTemplate == null ? "" : currentTemplate.UrlTemplate;

            var dbRecord = records.Where(c => c.PlatformId == platform.Id).FirstOrDefault();

            if (dbRecord == null)
            {
                // 创建记录
                var record = new PushRecord()
                {
                    UserId = msg.UserId,
                    MessageId = msg.Id,
                    PlatformId = platform.Id,

                    State = PushState.Waiting,
                    ExpirationTime = msg.ExpirationTime,
                    TemplateCode = currentTemplate.TemplateCode
                };

                if (currentTemplate.TemplateCode == "JNTemplate")
                {
                    record.Content = contentTemplateString == null ? msg.Title : JNTemplate(contentTemplateString, msg);
                    record.Url = urlTemplateString == null ? "" : JNTemplate(urlTemplateString, msg);
                }
                else
                {
                    record.Content = contentTemplateString == null ? msg.Title : ProcessTemplate(contentTemplateString, msg);
                    record.Url = urlTemplateString == null ? "" : ProcessTemplate(urlTemplateString, msg);
                }

                record.Content = record.Content.Replace("\n", "");

                if (string.IsNullOrEmpty(record.Content))
                {
                    return null;
                }

                return record;
            }

            return dbRecord;
        }

        private string ProcessTemplate(string template, Message msg)
        {
            var result = template.Replace("{{MessageId}}", msg.Id.ToString());

            result = template.Replace("{{Title}}", msg.Title);

            result = result.Replace("{{Description}}", msg.Description);

            result = result.Replace("{{CreateDate}}", msg.CreateTime.ToString("yyyy-MM-dd"));

            result = result.Replace("{{CreateTime}}", msg.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));

            if (string.IsNullOrEmpty(msg.Data)) return result;

            try
            {
                var jObject = JObject.Parse(msg.Data);

                var flattened = jObject.Flatten();

                foreach (var item in flattened)
                {
                    if (item.Value != null && (item.Value.GetType().Name == "Array" || item.Value.GetType().Name == "EmptyPartition`1"))
                    {
                        flattened.Remove(item.Key);
                    }
                }

                var flattenedJsonString = JsonConvert.SerializeObject(flattened, Formatting.Indented);

                var dataDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(flattenedJsonString);

                foreach (var item in dataDic)
                {
                    result = result.Replace("{{" + item.Key + "}}", item.Value);
                }
            }
            catch (Exception e)
            {
                Context.WriteLine($"ProcessTemplate:{msg.Id} 错误信息:" + e.Message);
            }

            return result;
        }

        private string JNTemplate(string template, Message msg)
        {
            var jnTemplate = Engine.CreateTemplate(template);

            jnTemplate.Set("MessageId", msg.Id.ToString());
            jnTemplate.Set("Title", msg.Title);
            jnTemplate.Set("Description", msg.Description);
            jnTemplate.Set("CreateDate", msg.CreateTime.ToString("yyyy-MM-dd"));
            jnTemplate.Set("CreateTime", msg.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));

            // Context.WriteLine(msg.Data);

            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(msg.Data);

            foreach (var item in data)
            {
                jnTemplate.Set(item.Key, item.Value);

                // Context.WriteLine($"{item.Key}:{item.Value.GetType().Name}:{item.Value}");
            }

            try
            {
                var result = jnTemplate.Render();

                // Context.WriteLine(result);

                return result;
            }
            catch (Exception e)
            {
                Context.WriteLine($"JNTemplate:{msg.Id} 错误信息:" + e.Message);
            }

            return "";
        }

        private bool CheckProcessing(string jobName)
        {
            var sql = $"select count(statename) from hangfire.job where invocationdata like '%{jobName}%' and statename = 'Processing'";
            var jobCount = _hangfireConn.QueryFirstOrDefault<int>(sql);

            return jobCount >= 2;
        }
    }
}
