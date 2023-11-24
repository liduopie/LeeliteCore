using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework
{
    public static class ElasticsearchServiceCollectionExtensions
    {
        public static void AddEsClientProvider(this IServiceCollection services)
        {
            services.AddScoped<IClientProvider, ClientProvider>();
        }
    }
}
