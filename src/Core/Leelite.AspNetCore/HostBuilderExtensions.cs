using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;
using Leelite.Core.Mapper;
using Leelite.Core.Modular;
using Leelite.Core.Module;
using Leelite.Core.Plugin;
using Leelite.Framework;

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureLeeliteWebCore(this IHostBuilder builder)
        {
            builder.ConfigureMapper();

            // 模块化加载的配置选项
            builder.ConfigureModuleOptions();
            builder.ConfigureModularOptions();

            // 模块仓库
            builder.ConfigureModuleStore();

            // 模块化管理器
            builder.ConfigureModular();

            builder.ConfigurePlugin();

            builder.ConfigureServices((hostContext, services) =>
            {
                HostManager.Context.HostServices = services.BuildServiceProvider();
            });

            // 配置模块
            builder.ConfigureModules();

            builder.ConfigurePlugins();

            return builder;
        }
    }
}
