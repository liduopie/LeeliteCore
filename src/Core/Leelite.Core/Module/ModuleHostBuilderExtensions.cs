using Leelite.Commons.Host;
using Leelite.Core.Modular;
using Leelite.Core.Module.Store;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leelite.Core.Module
{
    public static class ModuleHostBuilderExtensions
    {
        public static IHostBuilder ConfigureModuleOptions(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {
                services.Configure<ModuleOptions>(hostContext.Configuration.GetSection(nameof(ModuleOptions)));
            });

            return builder;
        }


        public static IHostBuilder ConfigureModuleStore(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IModuleStore, PhysicalFileModuleStore>();
            });

            return builder;
        }

        public static IHostBuilder ConfigureModules(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {

                var manager = HostManager.Context.HostServices.GetService<IModularManager>();

                manager.Load(HostManager.Context);

                services.AddSingleton(manager);
            });

            return builder;
        }
    }
}
