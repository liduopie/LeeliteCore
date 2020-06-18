using System.Collections.Concurrent;
using System.Reflection;

namespace Leelite.Commons.Convention
{
    public class ConventionContext
    {
        public ConventionContext()
        {
            Registrars = new BlockingCollection<IConventionRegistrar>();
        }

        /// <summary>
        /// 生命周期约定注册器集合
        /// </summary>
        public BlockingCollection<IConventionRegistrar> Registrars { get; }

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
            foreach (var registerer in Registrars)
            {
                RegisterAssembly(assembly, registerer);
            }
        }

        /// <summary>
        /// 注册程序集到指定的约定注册器中.
        /// </summary>
        /// <param name="assembly">要注册的程序集</param>
        /// <param name="registrar">指定的约定注册器</param>
        private static void RegisterAssembly(Assembly assembly, IConventionRegistrar registrar)
        {
            registrar.RegisterAssembly(assembly);
        }
    }
}