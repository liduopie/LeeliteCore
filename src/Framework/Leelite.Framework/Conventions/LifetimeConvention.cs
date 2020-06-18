using System;
using System.Linq;
using System.Reflection;
using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using Leelite.Commons.Lifetime;
using Leelite.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework.Conventions
{
    /// <summary>
    /// 生命周期约定注册器。
    /// </summary>
    public class LifetimeConvention : IConventionRegistrar
    {
        private readonly Type[] _lifetimeTypes ={
            typeof(ISingleton),
            typeof(IScope),
            typeof(ITransient)
        };

        public void RegisterAssembly(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            var builder = HostManager.Context.ServiceDescriptors;

            Type singletonType = typeof(ISingleton);

            builder.RegisterAssemblyTypes(assembly)
               .Where(type => singletonType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
               .AsInterface(i => i.GetInterfaces().Any(c => singletonType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
               .Singleton();

            Type scopeType = typeof(IScope);

            builder.RegisterAssemblyTypes(assembly)
                .Where(type => scopeType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .AsInterface(i => i.GetInterfaces().Any(c => scopeType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
                .Scope();

            Type transientType = typeof(ITransient);

            builder.RegisterAssemblyTypes(assembly)
                .Where(type => transientType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .AsInterface(i => i.GetInterfaces().Any(c => transientType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
                .Transient();

        }
    }
}
