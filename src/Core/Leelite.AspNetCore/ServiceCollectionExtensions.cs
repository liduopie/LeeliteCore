using System;
using Leelite.AspNetCore.Modular;
using Leelite.Core;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLeeliteWebCore(this IServiceCollection services, Action<IMvcBuilder> builderAction = null)
        {
            var mvcBuilder = services.AddModularMvc();

            builderAction?.Invoke(mvcBuilder);

            services.AddLeeliteCore();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });
        }
    }
}
