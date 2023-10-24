using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;

using Dapper;

using Hangfire.Console;
using Hangfire.Server;

using JsonFlatten;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.MessageCenter.Dtos.SessionDtos;
using Leelite.MessageCenter.Models.MessageAgg;
using Leelite.MessageCenter.Models.MessageTypeAgg;
using Leelite.MessageCenter.Models.SessionAgg;
using Leelite.MessageCenter.Repositories;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Npgsql;

namespace Leelite.MessageCenter.Jobs
{
    /// <summary>
    /// 会话展开成消息
    /// 后台持续执行
    /// </summary>
    public class SessionToMessagesJob : IBackgroundJob
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageTypeRepository _messageTypeRepository;

        private readonly IDictionary<int, MessageType> _messageTypes = new Dictionary<int, MessageType>();

        private readonly IDbConnection _hangfireConn;

        // 休眠时间
        private int _sleepTime = 1000;

        public SessionToMessagesJob(
            IConfiguration configuration,
            ISessionRepository sessionRepository,
            IMessageRepository messageRepository,
            IMessageTypeRepository messageTypeRepository)
        {
            _sessionRepository = sessionRepository;
            _messageRepository = messageRepository;
            _messageTypeRepository = messageTypeRepository;

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

            InitMessageType();

            context.WriteLine($"SessionToMessagesJob:已启动！");

            do
            {

                // 获取未处理的Session
                var parameter = new SessionQueryParameter()
                {
                    Pager = new PageParam()
                    {
                        PageSize = 100
                    },
                    States = new[] { CompleteState.Waiting },
                    Expired = false
                };

                try
                {
                    var total = _sessionRepository.Count(parameter.SatisfiedBy());

                    var query = new PagingQuery<Session, SessionQueryParameter>(parameter);

                    var sessions = _sessionRepository.FindPage(query);

                    if (total > 0)
                    {
                        _sleepTime = 1000;

                        context.WriteLine($"等待会话：{total}个，本次处理：{sessions.Count}个。");
                    }
                    else
                    {
                        _sleepTime = 10000;
                    }


                    foreach (var session in sessions)
                    {

                        if (!_messageTypes[session.MessageTypeId].IsEnabled) continue;

                        // 根据 session 展开成消息
                        CreateMessages(session);

                        session.State = CompleteState.Pushing;

                        _sessionRepository.Update(session);
                    }
                }
                catch (Exception e)
                {
                    context.WriteLine(e.Message);
                }

                // 休眠
                System.Threading.Thread.Sleep(_sleepTime);

            } while (true);
        }

        private void InitMessageType()
        {
            var msgTypes = _messageTypeRepository.Find();

            foreach (var msgType in msgTypes)
            {
                _messageTypes.Add(msgType.Id, msgType);
            }
        }

        /// <summary>
        /// 根据会话生成消息
        /// </summary>
        /// <param name="session"></param>
        private void CreateMessages(Session session)
        {
            var dbMessages = _messageRepository.Find(c => c.SessionId == session.Id);

            var messages = new List<Message>();

            foreach (var item in session.UserIds)
            {
                if (dbMessages.Any(c => c.UserId == item)) continue;

                var msgType = _messageTypes[session.MessageTypeId];

                var message = new Message()
                {
                    SessionId = session.Id,
                    UserId = item,
                    MessageTypeId = session.MessageTypeId,
                    Title = ProcessTemplate(msgType.TitleTemplate, session),
                    Description = ProcessTemplate(msgType.DescriptionTemplate, session),
                    Data = session.Data,
                    ReadState = false,
                    DeliveryState = false,
                    IsDeleted = false,
                    CreateTime = DateTime.Now,
                    ExpirationTime = DateTime.Now.AddDays(msgType.ValidDays)
                };

                messages.Add(message);
            }

            _messageRepository.AddRange(messages);

            Context.WriteLine($"会话：{session.Id}，生成消息{messages.Count}个。");
        }

        private string ProcessTemplate(string template, Session session)
        {
            if (string.IsNullOrEmpty(template)) return template;

            var result = template.Replace("{{Title}}", session.Title);

            result = result.Replace("{{Description}}", session.Description);

            if (string.IsNullOrEmpty(session.Data)) return result;

            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var jObject = JObject.Parse(session.Data);

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
                Context.WriteLine($"ProcessTemplate:{session.Id} 错误信息:" + e.Message);
                Context.WriteLine($"ProcessTemplate:{session.Id} Template:" + template);
            }

            return result;
        }

        private bool CheckProcessing(string jobName)
        {
            var sql = $"select count(statename) from hangfire.job where invocationdata like '%{jobName}%' and statename = 'Processing'";
            var jobCount = _hangfireConn.QueryFirstOrDefault<int>(sql);

            return jobCount >= 2;
        }
    }
}
