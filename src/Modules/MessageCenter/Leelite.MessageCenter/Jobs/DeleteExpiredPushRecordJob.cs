using Hangfire.Console;
using Hangfire.Server;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.MessageCenter.Dtos.PushRecordDtos;
using Leelite.MessageCenter.Models.PushRecordAgg;
using Leelite.MessageCenter.Repositories;

using System;

namespace Leelite.MessageCenter.Jobs
{
    [RecurringJob("1 16 * * *", RecurringJobId = "删除过期推送记录")]
    public class DeleteExpiredPushRecordJob : IRecurringJob
    {
        private readonly IPushRecordRepository _pushRecordRepository;

        public DeleteExpiredPushRecordJob(
           IPushRecordRepository pushRecordRepository)
        {
            _pushRecordRepository = pushRecordRepository;
        }

        public void Execute(PerformContext context)
        {
            // 获取过期的 Message
            var parameter = new PushRecordQueryParameter()
            {
                Pager = new PageParam()
                {
                    PageSize = 100
                },
                Expired = true
            };

            var query = new PagingQuery<PushRecord, PushRecordQueryParameter>(parameter);

            // create progress bar
            var progress = context.WriteProgressBar();

            var total = _pushRecordRepository.Count(parameter.SatisfiedBy());

            context.WriteLine($"过期状态推送记录共{total}个。");

            if (total == 0) return;

            do
            {
                try
                {
                    var sessions = _pushRecordRepository.FindPage(query);

                    _pushRecordRepository.RemoveRange(sessions);

                    context.WriteLine($"本次处理{sessions.Count}记录。");
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
