using Hangfire.Console;
using Hangfire.Server;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Modules.MessageCenter.Dtos.PushRecordDtos;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;
using Leelite.Modules.MessageCenter.Repositories;

using System.Collections.Generic;

namespace Leelite.Modules.MessageCenter.Jobs
{
    [RecurringJob("*/1 * * * *", RecurringJobId = "消息推送任务")]
    public class PushJob : IRecurringJob
    {
        private readonly IPushPlatformRepository _platformRepository;
        private readonly IPushRecordRepository _pushRecordRepository;
        private readonly IPushProviderFactory _pushProviderFactory;

        private readonly IDictionary<int, IPushProvider> _providerCache = new Dictionary<int, IPushProvider>();

        public PushJob(
            IPushPlatformRepository platformRepository,
            IPushRecordRepository pushRecordRepository,
            IPushProviderFactory providerFactory)
        {
            _platformRepository = platformRepository;
            _pushRecordRepository = pushRecordRepository;
            _pushProviderFactory = providerFactory;

            var platforms = _platformRepository.Find(c => c.IsEnabled);

            foreach (var item in platforms)
            {
                _providerCache.Add(item.Id, _pushProviderFactory.Create(item));
            }
        }

        public void Execute(PerformContext context)
        {
            // 获取过期的Session
            var parameter = new PushRecordQueryParameter()
            {
                Pager = new PageParam()
                {
                    PageSize = 100
                },

                Expired = false,
                States = new PushState[] { PushState.Waiting }
            };

            var query = new PagingQuery<PushRecord, PushRecordQueryParameter>(parameter);

            // create progress bar
            var progress = context.WriteProgressBar();

            var total = _pushRecordRepository.Count(parameter.SatisfiedBy());

            context.WriteLine($"待推送记录共{total}个。");

            if (total == 0) return;

            do
            {
                var records = _pushRecordRepository.FindPage(query);

                foreach (var record in records)
                {
                    if (_providerCache.ContainsKey(record.PlatformId))
                    {
                        if (_providerCache[record.PlatformId].Push(record))
                            record.State = PushState.Succeed;
                        else
                            record.State = PushState.Failed;
                    }
                    else
                    {
                        record.State = PushState.Failed;
                    }
                }

                _pushRecordRepository.UpdateRange(records);

                context.WriteLine($"本次处理{records.Count}记录。");

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
