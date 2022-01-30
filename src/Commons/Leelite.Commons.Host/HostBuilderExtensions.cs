using Leelite.Commons.Host;

namespace Microsoft.Extensions.Hosting
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureHost(this IHostBuilder builder)
        {
            // 获取主机配置
            var options = CoreHostOptions.Default;

            // 根据配置调整 Host

            // 配置依赖注入
            builder.ConfigureServices((hostContext, services) =>
            {
                // 2022-01-08 注释
                // HostManager.Context.ServiceDescriptors = services;
            });

            // 配置json配置文件
            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
            });

            // 配置日志
            builder.ConfigureLogging(logging =>
            {
            });

            // 2022-01-08 注释
            // builder.UseServiceProviderFactory(new CoreHostServiceProviderFactory());

            return builder;
        }
    }
}
