using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;
using Leelite.Core;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {

        static ServiceCollectionExtensions()
        {
            Logger = HostManager.DefaultHost.Services.GetService<ILoggerFactory>().CreateLogger("LeeliteWebCore");
        }

        private static ILogger Logger { get; set; }

        public static void AddLeeliteWebCore(this IServiceCollection services, IConfiguration configuration, Action<IMvcBuilder> builderAction = null)
        {
            var mvcBuilder = services.AddModularMvc();

            Logger.LogInformation($"AddLeeliteWebCore add ModularMvc.");

            builderAction?.Invoke(mvcBuilder);

            Logger.LogInformation($"AddLeeliteWebCore IMvcBuilder Action Invoke.");

            services.AddLeeliteCore(configuration);

            Logger.LogInformation($"AddLeeliteWebCore add LeeliteCore.");

            // TODO: 单页面程序配置
            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp";
            //});

            // Logger.LogInformation($"AddLeeliteWebCore add SpaStaticFiles.");
        }
    }
}
