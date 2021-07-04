using System;
using Hangfire;
using Hangfire.Console;
using Hangfire.RecurringJobExtensions;
using Hangfire.Server;
using Leelite.AspNetCore.Modular;
using Leelite.Core.Module.Dependency;
using Leelite.Modules.Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.PushCenter
{
    [DependsOn(typeof(HangfireModule))]
    public class PushCenterModule : MvcModuleBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var backgroundJobs = app.ApplicationServices.GetService<IBackgroundJobClient>();

            backgroundJobs.Enqueue(() => Console.WriteLine("Hello Push Center!"));

            RecurringJob.AddOrUpdate("easyjob", () => Console.Write("Easy!"), Cron.Minutely);
        }
    }

    public class RecurringJobService
    {
        [RecurringJob("*/1 * * * *")]
        [Queue("jobs")]
        public void TestJob1(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TestJob1 Running ...");
        }
        [RecurringJob("*/2 * * * *", RecurringJobId = "TestJob2")]
        [Queue("jobs")]
        public void TestJob2(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TestJob2 Running ...");
        }
        [RecurringJob("*/2 * * * *", "China Standard Time", "jobs")]
        public void TestJob3(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TestJob3 Running ...");
        }
        [RecurringJob("*/5 * * * *", "jobs")]
        public void InstanceTestJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} InstanceTestJob Running ...");
        }

        [RecurringJob("*/6 * * * *", "UTC", "jobs")]
        public static void StaticTestJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} StaticTestJob Running ...");
        }
    }
}
