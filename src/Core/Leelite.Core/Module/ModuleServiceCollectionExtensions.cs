using Leelite.Core.Module;

using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ModuleServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureModuleOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ModuleOptions>(configuration.GetSection(nameof(ModuleOptions)));

            return services;
        }
    }
}
