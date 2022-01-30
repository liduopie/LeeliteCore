using Microsoft.Extensions.DependencyInjection;

using System.Collections.Concurrent;
using System.Reflection;

namespace Leelite.Commons.Convention
{
    /// <summary>
    /// 此类用于执行规则注册。
    /// </summary>
    public static class ConventionManager
    {
        /// <summary>
        /// 单例实例
        /// </summary>
        private static readonly ConventionContext _context;

        static ConventionManager()
        {
            _context = new ConventionContext();
        }

        /// <summary>
        /// 设置程序集服务集合.
        /// </summary>
        /// <param name="services"></param>
        public static void SetServices(IServiceCollection services)
        {
            _context.SetServices(services);
        }

        /// <summary>
        /// 生命周期约定注册器集合
        /// </summary>
        public static BlockingCollection<IConventionRegistrar> Registrars
        {
            get { return _context.Registrars; }
        }

        /// <summary>
        /// 添加一个约定注册器
        /// </summary>
        /// <param name="registrar">约定注册器</param>
        public static void AddRegistrar(IConventionRegistrar registrar)
        {
            _context.AddRegistrar(registrar);
        }

        /// <summary>
        /// 注册程序集到所有的约定注册器中,参考 <see cref="AddConventionRegistrar"/> 方法.
        /// </summary>
        /// <param name="assembly">要注册的程序集</param>
        public static void RegisterAssembly(Assembly assembly)
        {
            _context.RegisterAssembly(assembly);
        }
    }
}