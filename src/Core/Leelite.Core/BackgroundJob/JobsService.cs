using Hangfire;
using Hangfire.Annotations;
using Hangfire.Server;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Reflection;

using TimeZoneConverter;

namespace Leelite.Core.BackgroundJob.Services
{
    /// <summary>
    /// 任务自动注册服务
    /// </summary>
    public class JobsService : BackgroundService
    {
        // TODO: 一次性任务没有实现自动注册
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ILogger<JobsService> _logger;
        private readonly IEnumerable<IBackgroundJob> _backgroundJobs;
        private readonly IEnumerable<IRecurringJob> _recurringJobs;

        public JobsService(
           [NotNull] IBackgroundJobClient backgroundJobClient,
           [NotNull] IRecurringJobManager recurringJobManager,
           [NotNull] ILogger<JobsService> logger,
           IEnumerable<IBackgroundJob> backgroundJobs,
           IEnumerable<IRecurringJob> recurringJobs)
        {
            _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
            _recurringJobManager = recurringJobManager ?? throw new ArgumentNullException(nameof(recurringJobManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _backgroundJobs = backgroundJobs;
            _recurringJobs = recurringJobs;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                foreach (var job in _backgroundJobs)
                {
                    var jobType = job.GetType();

                    var method = jobType.GetMethod("Execute", new Type[] { typeof(PerformContext) });
                    var jobInfo = new Hangfire.Common.Job(method, new object[] { null });

                    _backgroundJobClient.Create(jobInfo, new Hangfire.States.EnqueuedState());
                }

                foreach (var job in _recurringJobs)
                {
                    var jobType = job.GetType();

                    var attr = jobType.GetCustomAttribute<RecurringJobAttribute>();
                    if (attr == null) continue;

                    var method = jobType.GetMethod("Execute", new Type[] { typeof(PerformContext) });
                    var jobInfo = new Hangfire.Common.Job(method, []);

                    if (attr.Enabled)
                        _recurringJobManager.AddOrUpdate(attr.RecurringJobId, jobInfo, attr.Cron, TZConvert.GetTimeZoneInfo(attr.TimeZone), attr.Queue);
                    else
                        _recurringJobManager.RemoveIfExists(attr.RecurringJobId);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occurred while creating recurring jobs.");
            }

            return Task.CompletedTask;
        }
    }
}
