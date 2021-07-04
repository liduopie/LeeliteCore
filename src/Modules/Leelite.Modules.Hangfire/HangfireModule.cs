using System;
using System.Globalization;
using Hangfire;
using Hangfire.PostgreSql;

using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Hangfire.RecurringJobExtensions;

namespace Leelite.Modules.Hangfire
{
    public class HangfireModule : MvcModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            var config = context.HostServices.GetService<IConfiguration>();

            // Add Hangfire services.
            services.AddHangfire(configuration =>
            {
                configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(config.GetConnectionString("HangfireConnection"));

                configuration.UseDefaultActivator();

                configuration.UseConsole();

                //using json config file to build RecurringJob automatically.
                configuration.UseRecurringJob("recurringjob.json");
                //using RecurringJobAttribute to build RecurringJob automatically.
                configuration.UseRecurringJob(typeof(RecurringJobService));

            });

            // Add the processing server as IHostedService
            services.AddHangfireServer(option =>
            {
                option.ServerName = "Host Server";
            });

        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("zh-CN"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("zh-CN"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            //app.UseHangfireServer(new BackgroundJobServerOptions
            //{
            //    ServerName = "Host Server"
            //});

            // Make `Back to site` link working for subfolder applications
            //var options = new DashboardOptions { AppPath = "~" };
            app.UseHangfireDashboard();

            var backgroundJobs = app.ApplicationServices.GetService<IBackgroundJobClient>();
            backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
        }
    }
}
