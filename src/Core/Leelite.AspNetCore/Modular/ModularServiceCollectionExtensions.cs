using Microsoft.Extensions.DependencyInjection;

namespace Leelite.AspNetCore.Modular
{
    public static class ModularServiceCollectionExtensions
    {
        public static IMvcBuilder AddModularMvc(this IServiceCollection services)
        {
            // Add controllers as services so they'll be resolved.
            // AddControllers Api
            // AddControllersWithViews
            // AddRazorPages
            var mvcBuilder = services.AddMvc();

            // 添加到 AddApplicationPart
            mvcBuilder.AddModularPart();

            // 添加默认配置
            mvcBuilder.AddConfig();

            // 添加模块的Build
            mvcBuilder.AddBuild();

            return mvcBuilder;
        }
    }
}
