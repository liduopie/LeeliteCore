using Leelite.Core.Modular;
using Leelite.Core.Module.Store;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Leelite.AspNetCore.Modular
{
    public static class ModularHostBuilderExtensions
    {
        public static IHostBuilder ConfigureModular(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(sp =>
                    new ModularManager(sp.GetService<IOptions<ModularOptions>>(), sp.GetService<IModuleStore>())
                );
                services.AddSingleton<IModularManager>(sp => sp.GetService<ModularManager>());
                services.AddSingleton<IModduleLoaderManager>(sp => sp.GetService<ModularManager>());
            });

            return builder;
        }
    }
}
