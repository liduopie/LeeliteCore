﻿using Hangfire;
using Hangfire.Console;
using Hangfire.PostgreSql;

using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;
using Leelite.Core.Modular;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.Hangfire
{
    public class HangfireModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var config = HostManager.DefaultHost.Services.GetService<IConfiguration>();

            // Add Hangfire services.
            services.AddHangfire(configuration =>
            {
                configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(config?.GetConnectionString("HangfireConnection"));
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

            GlobalConfiguration.Configuration.UseConsole();

            // Make `Back to site` link working for subfolder applications
            // var options = new DashboardOptions { AppPath = "~" };
            app.UseHangfireDashboard();

            // 添加类型解释，通过模块加载的dll中查找，默认程序集中是不包含模块dll的
            GlobalConfiguration.Configuration.UseTypeResolver(DefaultTypeResolver);
        }

        public Type? DefaultTypeResolver(string typeName)
        {
            return Type.GetType(
                typeName,
                typeResolver: TypeResolver,
                assemblyResolver: ModuleAssemblyResolver,
                throwOnError: true);
        }

        private Assembly ModuleAssemblyResolver(AssemblyName assemblyName)
        {
            var _modularManager = HostManager.WebApplication.Services.GetRequiredService<IModularManager>();

            foreach (var context in _modularManager.ModuleContexts)
            {
                var res = context.Assemblies.Where(c => c.GetName().Name == assemblyName.FullName).FirstOrDefault();

                if (res != null)
                    return res;
            }

            var publicKeyToken = assemblyName.GetPublicKeyToken();

            try
            {
                return Assembly.Load(assemblyName);
            }
            catch (Exception)
            {
                var shortName = new AssemblyName(assemblyName.Name ?? "");
                if (publicKeyToken != null)
                {
                    shortName.SetPublicKeyToken(publicKeyToken);
                }

                return Assembly.Load(shortName);
            }
        }

        private Type? TypeResolver(Assembly? assembly, string typeName, bool ignoreCase)
        {
            if (typeName.Equals("System.Diagnostics.Debug", StringComparison.Ordinal))
            {
                return typeof(System.Diagnostics.Debug);
            }

            Type? type = null;

            assembly = assembly ?? typeof(int).GetTypeInfo().Assembly;
            try
            {
                type = assembly.GetType(typeName, true, ignoreCase);
            }
            catch (Exception)
            {
            }

            return type;
        }
    }
}
