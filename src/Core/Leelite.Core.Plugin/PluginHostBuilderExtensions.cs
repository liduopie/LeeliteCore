using Microsoft.Extensions.Hosting;

namespace Leelite.Core.Plugin
{
    public static class PluginHostBuilderExtensions
    {
        public static IHostBuilder ConfigurePlugin(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {

            });

            return builder;
        }

        public static IHostBuilder ConfigurePlugins(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {

            });

            return builder;
        }
    }
}
