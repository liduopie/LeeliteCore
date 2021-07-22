using Hangfire.Console;
using Hangfire.Server;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Modules.MessageCenter.Dtos.MessageDtos;
using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;
using Leelite.Modules.MessageCenter.Repositories;

using System;
using System.Linq;
using System.Collections.Generic;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Leelite.Modules.MessageCenter.Models.TemplateAgg;

namespace Leelite.Modules.MessageCenter.Jobs
{
    [RecurringJob("*/1 * * * *", RecurringJobId = "将消息展开成推送记录")]
    public class MessageToPushRecordsJob : IRecurringJob
    {
        private readonly IMessageTypeRepository _messageTypeRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IPushRecordRepository _recordRepository;
        private readonly IPushPlatformRepository _platformRepository;

        private readonly IDictionary<int, MessageType> _messageTypes = new Dictionary<int, MessageType>();
        private readonly List<Template> _templates = new List<Template>();
        private readonly List<PushPlatform> _platforms = new List<PushPlatform>();

        public MessageToPushRecordsJob(
            IMessageTypeRepository messageTypeRepository,
            IMessageRepository messageRepository,
            ITemplateRepository templateRepository,
            IPushRecordRepository recordRepository,
            IPushPlatformRepository platformRepository)
        {
            _messageTypeRepository = messageTypeRepository;
            _messageRepository = messageRepository;
            _templateRepository = templateRepository;
            _recordRepository = recordRepository;
            _platformRepository = platformRepository;
        }

        public PerformContext Context { get; set; }

        public void Execute(PerformContext context)
        {
            Context = context;

            // 获取未处理的Message
            var parameter = new MessageQueryParameter()
            {
                Pager = new PageParam()
                {
                    PageSize = 100
                },
                ReadState = false,
                EndCreateTime = DateTime.Now,
                Delivered = false
            };


            var query = new PagingQuery<Message, MessageQueryParameter>(parameter);

            // create progress bar
            var progress = context.WriteProgressBar();

            var total = _messageRepository.Count(parameter.SatisfiedBy());

            context.WriteLine($"等待状态会话共{total}个。");

            if (total == 0) return;

            InitPlatform();
            InitMessageType();
            InitMessageTemplate();

            do
            {
                var messages = _messageRepository.FindPage(query);

                context.WriteLine($"本次处理{messages.Count}会话。");

                foreach (var msg in messages)
                {
                    // 根据 message 展开成消息
                    CreatePushRecords(msg);
                }

                parameter.Pager.Page++;

                // update value for previously created progress bar
                if (parameter.Pager.GetSkipCount() >= total)
                {
                    progress.SetValue(100);
                }
                else
                {
                    progress.SetValue(parameter.Pager.GetSkipCount() * 100 / total);
                }
            } while (parameter.Pager.GetSkipCount() < total);
        }

        private void InitPlatform()
        {
            _platforms.AddRange(_platformRepository.Find(c => c.IsEnabled == true).OrderBy(c => c.Priority));
        }

        private void InitMessageType()
        {
            var msgTypes = _messageTypeRepository.Find(c => c.IsEnabled);

            foreach (var msgType in msgTypes)
            {
                _messageTypes.Add(msgType.Id, msgType);
            }
        }

        private void InitMessageTemplate()
        {
            _templates.AddRange(_templateRepository.Find());
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
                                 select d).ToList();

            var data = msg.Data;



            // 序列模式
            if (msgType.PushStrategy == PushStrategy.Sequence)
            {
                foreach (var platform in validPlatform)
                {
                    var record = BuildRecord(platform, msgType, msg, dbRecords);

                    if (record.Id == 0)
                    {
                        newRecords.Add(record);
                        break;
                    }

                    if (record.State == PushState.Succeed)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            if (msgType.PushStrategy == PushStrategy.All)
            {
                foreach (var platform in validPlatform)
                {
                    var record = BuildRecord(platform, msgType, msg, dbRecords);

                    if (record.Id == 0)
                    {
                        newRecords.Add(record);
                    }
                }
            }

            _recordRepository.AddRange(newRecords);

            Context.WriteLine($"消息：{msg.Id}，生成推送{newRecords.Count}个。");
        }

        private PushRecord BuildRecord(PushPlatform platform, MessageType type, Message msg, IList<PushRecord> records)
        {
            var currentTemplate = _templates.Where(c => c.PlatformId == platform.Id && c.MessageTypeCode == type.Code).FirstOrDefault();

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
                    Content = contentTemplateString == null ? msg.Title : ProcessTemplate(contentTemplateString, msg),
                    Url = urlTemplateString == null ? "" : ProcessTemplate(urlTemplateString, msg),
                    State = PushState.Waiting,
                    ExpirationTime = msg.ExpirationTime,
                    TemplateCode = currentTemplate.TemplateCode
                };
                return record;
            }

            return dbRecord;
        }

        private string ProcessTemplate(string template, Message msg)
        {
            var result = template.Replace("{{Title}}", msg.Title);

            result = result.Replace("{{Description}}", msg.Description);

            foreach (var item in msg.Data)
            {
                result = result.Replace($"{{{item.Key}}}", item.Value);
            }

            return result;
        }
    }
}
