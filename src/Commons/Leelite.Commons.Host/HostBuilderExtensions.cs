using System;
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

            builder.ConfigureServices((hostContext, services) =>
            {
                HostManager.Context.ServiceDescriptors = services;
            });

            builder.UseServiceProviderFactory(new CoreHostServiceProviderFactory());

            return builder;
        }
    }
}
