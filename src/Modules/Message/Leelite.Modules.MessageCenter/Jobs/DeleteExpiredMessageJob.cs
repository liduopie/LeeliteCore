using Hangfire.Console;
using Hangfire.Server;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Modules.MessageCenter.Dtos.MessageDtos;
using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Leelite.Modules.MessageCenter.Repositories;

namespace Leelite.Modules.MessageCenter.Jobs
{
    [RecurringJob("*/1 * * * *", RecurringJobId = "删除过期消息")]
    public class DeleteExpiredMessageJob : IRecurringJob
    {
        private readonly IMessageRepository _messageRepository;

        public DeleteExpiredMessageJob(
           IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Execute(PerformContext context)
        {
            // 获取过期的 Message
            var parameter = new MessageQueryParameter()
            {
                Pager = new PageParam()
                {
                    PageSize = 100
                },
                Expired = true,
                
            };

            var query = new PagingQuery<Message, MessageQueryParameter>(parameter);

            // create progress bar
            var progress = context.WriteProgressBar();

            var total = _messageRepository.Count(parameter.SatisfiedBy());

            context.WriteLine($"过期状态消息共{total}个。");

            if (total == 0) return;

            do
            {
                var sessions = _messageRepository.FindPage(query);

                _messageRepository.RemoveRange(sessions);

                context.WriteLine($"本次处理{sessions.Count}消息。");

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
    }
}
