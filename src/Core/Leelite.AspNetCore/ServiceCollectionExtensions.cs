using System;

using Leelite.AspNetCore.Modular;
using Leelite.Core;

using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {


        public static void AddLeeliteWebCore(this IServiceCollection services, IConfiguration configuration, Action<IMvcBuilder> builderAction = null)
        {
            // TODO:
            var mvcBuilder = services.AddModularMvc();

            // TODO:
            //builderAction?.Invoke(mvcBuilder);

            services.AddLeeliteCore(configuration);

            // TODO: 单页面程序配置
            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp";
            //});
        }
    }
}
