using System;
using System.Collections.Generic;
using System.Text;

using Hangfire;
using Hangfire.PostgreSql;

using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.Hangfire
{
    public class HangfireModule : MvcModuleStartupBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            var config = context.HostServices.GetService<IConfiguration>();

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(config.GetConnectionString("HangfireConnection")));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Make `Back to site` link working for subfolder applications
            //var options = new DashboardOptions { AppPath = "~" };

            app.UseHangfireDashboard();

            var backgroundJobs = app.ApplicationServices.GetService<IBackgroundJobClient>();
            backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
        }
    }
}
