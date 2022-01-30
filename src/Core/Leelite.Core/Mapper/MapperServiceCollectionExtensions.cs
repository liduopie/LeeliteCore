using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Mapper
{
    public static class MapperServiceCollectionExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton(MapperConfigurationManager.Context.CreateMapper());
        }
    }
}
