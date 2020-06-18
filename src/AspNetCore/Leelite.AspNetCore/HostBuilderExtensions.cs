using Leelite.AspNetCore.Assembly;
using Leelite.Commons.Host;
using Leelite.Core.Mapper;
using Leelite.Core.Modular;
using Leelite.Core.Plugin;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureLeeliteWebCore(this IHostBuilder builder)
        {
            builder.ConfigureAssermblyLoader();

            builder.ConfigureMapper();

            // builder.ConfigureConvention();

            builder.ConfigureModular();

            builder.ConfigurePlugin();

            builder.ConfigureServices((hostContext, services) =>
            {
                HostManager.Context.HostServices = services.BuildServiceProvider();
            });

            builder.ConfigureModules();

            builder.ConfigurePlugins();

            return builder;
        }
    }
}
