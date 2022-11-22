using Leelite.Commons.Host;
using Leelite.Core.Cache;
using Leelite.Core.Mapper;
using Leelite.Core.Modular;
using Leelite.Core.Module;
using Leelite.Core.Module.Store;

using MediatR;
using MediatR.Registration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leelite.Core
{
    public static class CoreServiceCollectionExtensions
    {
        static CoreServiceCollectionExtensions()
        {
            Logger = HostManager.DefaultHost.Services.GetService<ILoggerFactory>().CreateLogger("LeeliteCore");
        }

        private static ILogger Logger { get; set; }

        public static void ConfigureLeeliteCore(this IServiceCollection services, IConfiguration configuration)
        {
            // 模块化加载的配置选项
            services.Configure<ModuleOptions>(configuration.GetSection(nameof(ModuleOptions)));
            services.Configure<ModularOptions>(configuration.GetSection(nameof(ModularOptions)));

            Logger.LogInformation($"ConfigureLeeliteCore completed modular options configure.");

            // 模块仓库
            var moduleOptions = new ModuleOptions();
            configuration.GetSection(nameof(ModuleOptions)).Bind(moduleOptions);

            var store = new PhysicalFileModuleStore(moduleOptions);

            services.AddSingleton<IModuleStore>(store);

            Logger.LogInformation($"ConfigureLeeliteCore completed physical file module store instance.");

            // 模块化管理器
            var modularOptions = new ModularOptions();
            configuration.GetSection(nameof(ModularOptions)).Bind(modularOptions);

            var manager = new ModularManager(store, modularOptions);

            // 加载模块
            manager.Loading(services, configuration);

            services.AddSingleton<IModularManager>(manager);

            Logger.LogInformation($"ConfigureLeeliteCore completed modular manager instance.");
        }

        public static void AddLeeliteCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCache(configuration);

            Logger.LogInformation($"AddLeeliteCore add Cache.");

            services.AddMapper();

            Logger.LogInformation($"AddLeeliteCore add Mapper.");

            // services.AddSignalR();

            // Logger.LogInformation($"AddLeeliteCore add SignalR.");

            var serviceConfig = new MediatRServiceConfiguration();

            serviceConfig.AsScoped();

            ServiceRegistrar.AddRequiredServices(services, serviceConfig);

            Logger.LogInformation($"AddLeeliteCore add MediatR.");
        }
    }
}
