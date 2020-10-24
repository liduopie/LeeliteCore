using System.IO;

using HealthChecks.UI.Client;

using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;
using Leelite.Core.Modular.Dependency;
using Leelite.Core.Modular.Module;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.HealthChecks.UI
{
    [DependsOn(typeof(HealthChecksModule))]
    public class HealthChecksUIModule : MvcModuleStartupBase
    {
        private bool _enabled = false;

        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            var config = context.HostServices.GetService<IConfiguration>();
            _enabled = config.GetValue<bool>("HealthChecks");

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
                config.MapHealthChecksUI(setup =>
                {
                    setup.AddCustomStylesheet(Path.Combine(this.GetModuleEntry(app.ApplicationServices).ModulePath, "assets/dotnet.css"));
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
        }
    }
}
