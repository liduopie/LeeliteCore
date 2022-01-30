using Microsoft.Extensions.DependencyInjection;

using System.Collections.Concurrent;
using System.Reflection;

namespace Leelite.Commons.Convention
{
    public class ConventionContext
    {
        private IServiceCollection? _services;

        public ConventionContext()
        {
            Registrars = new BlockingCollection<IConventionRegistrar>();
        }

        /// <summary>
        /// 生命周期约定注册器集合
        /// </summary>
        public BlockingCollection<IConventionRegistrar> Registrars { get; }

        /// <summary>
        /// 组成应用程序的服务集合.
        /// </summary>
        public IServiceCollection Services
        {
            get
            {
                if (_services == default)
                {
                    throw new NullReferenceException("Please initialize Services.");
                }
                return _services;
            }
            private set
            {
                _services = value;
            }
        }

        /// <summary>
        /// 添加一个约定注册器
        /// </summary>
        /// <param name="registrar">约定注册器</param>
        public void AddRegistrar(IConventionRegistrar registrar)
        {
            Registrars.Add(registrar);
        }

        /// <summary>
        /// 注册程序集到所有的约定注册器中,参考 <see cref="AddConventionRegistrar"/> 方法.
        /// </summary>
        /// <param name="assembly">要注册的程序集</param>
        public void RegisterAssembly(Assembly assembly)
        {
            foreach (var registrar in Registrars)
            {
                registrar.RegisterAssembly(assembly, Services);
            }
        }

        /// <summary>
        /// 设置程序集服务集合.
        /// </summary>
        /// <param name="services"></param>
        public void SetServices(IServiceCollection services)
        {
            Services = services;
        }
    }
}