﻿using HealthChecks.UI.Client;

using Leelite.Application;
using Leelite.AspNetCore.Modular;
using Leelite.Core.Module.Dependency;
using Leelite.HealthChecks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Web
{
    [DependsOn(typeof(HealthChecksModule))]
    public class HealthChecksUIModule : MvcModuleBase
    {
        private bool _enabled = false;

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            _enabled = configuration.GetValue<bool>("HealthChecks");

            if (!_enabled) return;

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("HTTP-Api-Basic", "/healthz");
                setup.AddHealthCheckEndpoint("Process", "/health-process");
                setup.AddHealthCheckEndpoint("Database", "/health-database");
            }).AddInMemoryStorage();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!_enabled) return;

            app.UseRouting().UseEndpoints(config =>
            {
                config.MapHealthChecks("/health", new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                config.MapHealthChecksUI(setup =>
                {
                    //setup.AddCustomStylesheet(Path.Combine(this.GetModuleInfo(app.ApplicationServices).DirectoryPath, "assets/dotnet.css"));
                });

                config.MapHealthChecks("/healthz", new HealthCheckOptions
                {
                    Predicate = r => r.Tags.Count == 0,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                config.MapHealthChecks("/health-process", new HealthCheckOptions
                {
                    Predicate = r => r.Tags.Contains("process"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                config.MapHealthChecks("/health-database", new HealthCheckOptions
                {
                    Predicate = r => r.Tags.Contains("database"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            var client = ApplicationManager.Clients.Find(c => c.Code == "Admin");

            if (client != null)
            {
                client.Shortcuts.Add(new Application.Clients.NavItem("_blank", "/global_assets/images/logos/2.svg", "HealthChecks", "运行状况检查", "/healthchecks-ui", "Admin", ""));
            }
        }
    }
}
