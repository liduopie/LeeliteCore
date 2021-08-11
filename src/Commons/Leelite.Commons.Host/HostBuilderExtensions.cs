using System;
using Leelite.Commons.Host;
using Microsoft.Extensions.Logging;

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
                HostManager.Context.ServiceDescriptors = services;
            });

            // 配置json配置文件
            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
            });

            // 配置日志
            builder.ConfigureLogging(logging =>
            {
            });

            builder.UseServiceProviderFactory(new CoreHostServiceProviderFactory());

            return builder;
        }
    }
}
