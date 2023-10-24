using Hangfire.Console;
using Hangfire.Server;

using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.MessageCenter.Dtos.PushRecordDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.PushRecordAgg;
using Leelite.MessageCenter.Repositories;

using System;
using System.Collections.Generic;

namespace Leelite.MessageCenter.Jobs
{
    public class BasePushJob : IPushJob
    {
        private readonly IMessageService _messageService;
        private readonly IPushPlatformRepository _platformRepository;
        private readonly IPushRecordRepository _pushRecordRepository;
        private readonly IPushProviderFactory _pushProviderFactory;

        private readonly IDictionary<int, IPushProvider> _providerCache = new Dictionary<int, IPushProvider>();

        // 休眠时间
        private int _sleepTime = 1000;


        public BasePushJob(
            IMessageService messageService,
            IPushPlatformRepository platformRepository,
            IPushRecordRepository pushRecordRepository,
            IPushProviderFactory providerFactory)
        {
            _messageService = messageService;
            _platformRepository = platformRepository;
            _pushRecordRepository = pushRecordRepository;
            _pushProviderFactory = providerFactory;

            var platforms = _platformRepository.Find(c => c.IsEnabled);

            foreach (var item in platforms)
            {
                _providerCache.Add(item.Id, _pushProviderFactory.Create(item));
            }
        }

        public int SleepInterval { get; set; } = 10000;

        public void SetSleepInterval(int interval)
        {
            SleepInterval = interval;
        }

        /// <summary>
        /// 处理的主题组
        /// </summary>
        public IList<string> Topics { get; set; } = new List<string>() { null };

        public void SetTopics(IList<string> topics)
        {
            Topics = topics;
        }

        public void Execute(PerformContext context)
        {
            do
            {
                // 获取过期的Session
                var parameter = new PushRecordQueryParameter()
                {
                    Pager = new PageParam()
                    {
                        PageSize = 100
                    },

                    Expired = false,
                    States = new PushState[] { PushState.Waiting },
                    Topics = Topics
                };

                try
                {
                    var total = _pushRecordRepository.Count(parameter.SatisfiedBy());

                    var query = new PagingQuery<PushRecord, PushRecordQueryParameter>(parameter);

                    var records = _pushRecordRepository.FindPage(query);

                    if (total > 0)
                    {
                        _sleepTime = 1000;

                        context.WriteLine($"等待记录：{total}个，本次处理：{records.Count}个。");
                    }
                    else
                    {
                        _sleepTime = SleepInterval;
                    }

                    foreach (var record in records)
                    {
                        record.RetriesNum++;

                        if (!_providerCache.ContainsKey(record.PlatformId))
                        {
                            record.State = PushState.Failed;
                            continue;
                        }

                        var provider = _providerCache[record.PlatformId];

                        if (provider == null) continue;

                        provider.SetPerformContext(context); // 控制台输出必须提前

                        try
                        {
                            if (provider.Push(record))
                            {
                                record.State = PushState.Succeed;
                                _messageService.Delivered(record.MessageId);
                            }
                            else
                            {
                                record.State = PushState.Failed;
                            }
                        }
                        catch (Exception e)
                        {
                            record.State = PushState.Failed;
                            context.WriteLine($"{provider.ProviderName}:{record.Id}:{e.Message}");
                        }
                    }

                    _pushRecordRepository.UpdateRange(records);
                }
                catch (Exception e)
                {
                    context.WriteLine(e);
                }

                // 休眠
                System.Threading.Thread.Sleep(_sleepTime);

            } while (true);
        }
    }
}
