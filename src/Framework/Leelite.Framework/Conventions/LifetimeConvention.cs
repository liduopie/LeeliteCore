using Leelite.Commons.Convention;
using Leelite.Commons.Lifetime;
using Leelite.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

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

        public void RegisterAssembly(Assembly assembly, IServiceCollection services)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            Type singletonType = typeof(ISingleton);

            services.RegisterAssemblyTypes(assembly)
               .Where(type => singletonType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
               .AsInterface(i => i.GetInterfaces().Any(c => singletonType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
               .Singleton();

            Type scopeType = typeof(IScope);

            services.RegisterAssemblyTypes(assembly)
                .Where(type => scopeType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .AsInterface(i => i.GetInterfaces().Any(c => scopeType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
                .Scope();

            Type transientType = typeof(ITransient);

            services.RegisterAssemblyTypes(assembly)
                .Where(type => transientType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .AsInterface(i => i.GetInterfaces().Any(c => transientType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
                .Transient();
        }
    }
}
