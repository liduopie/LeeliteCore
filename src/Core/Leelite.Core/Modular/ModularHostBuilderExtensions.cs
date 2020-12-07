using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leelite.Core.Modular
{
    public static class ModularHostBuilderExtensions
    {
        public static IHostBuilder ConfigureModularOptions(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {
                services.Configure<ModularOptions>(hostContext.Configuration.GetSection(nameof(ModularOptions)));
            });

            return builder;
        }
    }
}
