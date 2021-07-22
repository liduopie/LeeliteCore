using Hangfire;
using Hangfire.Console;
using Hangfire.Server;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Modules.MessageCenter.Dtos.SessionDtos;
using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;
using Leelite.Modules.MessageCenter.Models.SessionAgg;
using Leelite.Modules.MessageCenter.Repositories;

using System.Collections.Generic;
using System.Linq;

namespace Leelite.Modules.MessageCenter.Jobs
{
    [RecurringJob("*/1 * * * *", RecurringJobId = "将会话展开成用户消息")]
    public class SessionToMessagesJob : IRecurringJob
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageTypeRepository _messageTypeRepository;

        private readonly IDictionary<int, MessageType> _messageTypes = new Dictionary<int, MessageType>();

        public SessionToMessagesJob(
            ISessionRepository sessionRepository,
            IMessageRepository messageRepository,
            IMessageTypeRepository messageTypeRepository)
        {
            _sessionRepository = sessionRepository;
            _messageRepository = messageRepository;
            _messageTypeRepository = messageTypeRepository;
        }

        public PerformContext Context { get; set; }

        public void Execute(PerformContext context)
        {
            Context = context;

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

            var query = new PagingQuery<Session, SessionQueryParameter>(parameter);

            // create progress bar
            var progress = context.WriteProgressBar();

            var total = _sessionRepository.Count(parameter.SatisfiedBy());

            context.WriteLine($"等待状态会话共{total}个。");

            if (total == 0) return;

            InitMessageType();

            do
            {
                var sessions = _sessionRepository.FindPage(query);

                context.WriteLine($"本次处理{sessions.Count}会话。");

                foreach (var session in sessions)
                {

                    if (!_messageTypes[session.MessageTypeId].IsEnabled) continue;

                    // 根据 session 展开成消息
                    CreateMessages(session);

                    session.State = CompleteState.Pushing;

                    _sessionRepository.Update(session);
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
                var msg = _messageRepository.Find(c => c.UserId == item && c.SessionId == session.Id);

                if (dbMessages.Any(c => c.UserId == item)) continue;

                var message = new Message()
                {
                    SessionId = session.Id,
                    UserId = item,
                    MessageTypeId = session.MessageTypeId,
                    Title = session.Title,
                    Description = session.Description,
                    Data = session.Data,
                    ReadState = false,
                    DeliveryState = false,
                    IsDeleted = false,
                    CreateTime = session.CreateTime,
                    ExpirationTime = session.ExpirationTime
                };

                messages.Add(message);
            }

            _messageRepository.AddRange(messages);

            Context.WriteLine($"会话：{session.Id}，生成消息{messages.Count}个。");
        }

    }
}
