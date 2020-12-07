using Leelite.Commons.Host;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Mapper
{
    public static class MapperServiceCollectionExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var context = HostManager.Context.HostServices.GetService<MapperConfigurationContext>();

            services.AddSingleton(context.CreateMapper());
        }
    }
}
