using Hangfire;
using Hangfire.Annotations;
using Hangfire.Server;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using TimeZoneConverter;

namespace Leelite.Core.BackgroundJob.Services
{
    /// <summary>
    /// 任务自从注册服务
    /// </summary>
    public class JobsService : BackgroundService
    {
        // TODO: 一次性任务没有实现自动注册
        private readonly IBackgroundJobClient _backgroundJobs;
        private readonly IRecurringJobManager _recurringJobs;
        private readonly ILogger<JobsService> _logger;
        private readonly IEnumerable<IRecurringJob> _jobs;

        public JobsService(
           [NotNull] IBackgroundJobClient backgroundJobs,
           [NotNull] IRecurringJobManager recurringJobs,
           [NotNull] ILogger<JobsService> logger,
           IEnumerable<IRecurringJob> jobs)
        {
            _backgroundJobs = backgroundJobs ?? throw new ArgumentNullException(nameof(backgroundJobs));
            _recurringJobs = recurringJobs ?? throw new ArgumentNullException(nameof(recurringJobs));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _jobs = jobs;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                foreach (var job in _jobs)
                {
                    var jobType = job.GetType();

                    var attr = jobType.GetCustomAttribute<RecurringJobAttribute>();
                    if (attr == null) continue;

                    var method = jobType.GetMethod("Execute", new Type[] { typeof(PerformContext) });
                    var jobInfo = new Hangfire.Common.Job(method, new object[] { null });

                    _recurringJobs.AddOrUpdate(attr.RecurringJobId, jobInfo, attr.Cron, TZConvert.GetTimeZoneInfo(attr.TimeZone), attr.Queue);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("An exception occurred while creating recurring jobs.", e);
            }

            return Task.CompletedTask;
        }
    }
}
