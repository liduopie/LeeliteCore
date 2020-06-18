using Leelite.Commons.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leelite.Core.Modular
{
    public static class ModularHostBuilderExtensions
    {
        public static IHostBuilder ConfigureModular(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IModularManager>(new ModularManager());
            });

            return builder;
        }

        public static IHostBuilder ConfigureModules(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {
                var manager = HostManager.Context.HostServices.GetService<IModularManager>();

                manager.Load();

                manager.ConfigureServices(HostManager.Context);
            });

            return builder;
        }
    }
}
