using Dapper;

using Hangfire;
using Hangfire.Console;
using Hangfire.Server;

using JinianNet.JNTemplate;

using Leelite.Core.BackgroundJob;

using Microsoft.Extensions.Configuration;

using Npgsql;

using System.Collections.Generic;
using System.Data;

namespace Leelite.MessageCenter.Jobs
{
    /// <summary>
    /// 消息推送任务
    /// 后台持续执行
    /// </summary>
    public class DefaultPushJob : IBackgroundJob
    {
        private readonly IDbConnection _hangfireConn;
        private readonly IPushJob _pushJob;

        public DefaultPushJob(IConfiguration configuration, IPushJob pushJob)
        {
            var connStr = configuration.GetConnectionString("HangfireConnection");
            _hangfireConn = new NpgsqlConnection(connStr);

            _pushJob = pushJob;
            _pushJob.SetTopics(new List<string>() { null });
        }

        public PerformContext Context { get; set; }

        [Queue("alpha")]
        public void Execute(PerformContext context)
        {
            Context = context;

            // 如果任务正在运行 结束任务
            if (CheckProcessing(this.GetType().FullName))
            {
                context.WriteLine($"任务正在运行，对出当前任务！");
                return;
            }

            context.WriteLine($"PushJob:已启动！");

            _pushJob.Execute(context);

            context.WriteLine($"PushJob:停止！");
        }

        private bool CheckProcessing(string jobName)
        {
            var sql = $"select count(statename) from hangfire.job where invocationdata like '%{jobName}%' and statename = 'Processing'";
            var jobCount = _hangfireConn.QueryFirstOrDefault<int>(sql);

            return jobCount >= 2;
        }
    }
}
