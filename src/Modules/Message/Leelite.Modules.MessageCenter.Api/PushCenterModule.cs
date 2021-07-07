using System;

using Hangfire;

using Leelite.AspNetCore.Modular;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter
{
    public class MessageCenterModule : MvcModuleBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var backgroundJobs = app.ApplicationServices.GetService<IBackgroundJobClient>();

            backgroundJobs.Enqueue(() => Console.WriteLine("Hello Push Center!"));

            //RecurringJob.AddOrUpdate("easyjob", () => Console.Write("Easy!"), Cron.Minutely);
        }
    }
}
