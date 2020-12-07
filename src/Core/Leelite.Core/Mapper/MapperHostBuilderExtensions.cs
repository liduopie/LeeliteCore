using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leelite.Core.Mapper
{
    public static class MapperHostBuilderExtensions
    {
        public static IHostBuilder ConfigureMapper(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(new MapperConfigurationContext());
            });

            return builder;
        }
    }
}
