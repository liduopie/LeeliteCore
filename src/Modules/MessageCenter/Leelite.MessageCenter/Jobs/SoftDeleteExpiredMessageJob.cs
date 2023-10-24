using System;

using Hangfire.Console;
using Hangfire.Server;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Models.SoftDelete;
using Leelite.MessageCenter.Dtos.MessageDtos;
using Leelite.MessageCenter.Models.MessageAgg;
using Leelite.MessageCenter.Repositories;

namespace Leelite.MessageCenter.Jobs
{
    [RecurringJob("1 16 * * *", RecurringJobId = "软删除过期消息")]
    public class SoftDeleteExpiredMessageJob : IRecurringJob
    {
        private readonly IMessageRepository _messageRepository;

        public SoftDeleteExpiredMessageJob(
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
                Expired = true
            };

            var query = new PagingQuery<Message, MessageQueryParameter>(parameter);

            // create progress bar
            var progress = context.WriteProgressBar();

            var total = _messageRepository.Count(parameter.SatisfiedBy());

            context.WriteLine($"过期状态消息共{total}个。");

            if (total == 0) return;

            do
            {
                try
                {
                    var messages = _messageRepository.FindPage(query);

                    foreach (var msg in messages)
                    {
                        msg.Delete();
                    }

                    _messageRepository.UpdateRange(messages);

                    context.WriteLine($"本次处理{messages.Count}消息。");
                }
                catch (Exception e)
                {
                    context.WriteLine(e.Message);
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
    }
}
