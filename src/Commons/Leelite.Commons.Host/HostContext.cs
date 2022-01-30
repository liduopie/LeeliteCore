using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leelite.Commons.Host
{
    public class HostContext
    {
        /// <summary>
        /// 当前主机的依赖注入容器
        /// </summary>
        public IServiceProvider HostServices { get; set; }

        /// <summary>
        /// 当前主机程序的依赖注入配置
        /// </summary>
        public IServiceCollection ServiceDescriptors { get; set; }

        /// <summary>
        /// 当前运行的主机
        /// </summary>
        public IHost Host { get; set; }
    }
}
