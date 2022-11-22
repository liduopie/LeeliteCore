using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using Leelite.Commons.Lifetime;
using Leelite.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

#if DEBUG
            DebugLog(assembly, singletonType);
#endif

            services.RegisterAssemblyTypes(assembly)
               .Where(type => singletonType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
               .AsInterface(i => i.GetInterfaces().Any(c => singletonType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
               .Singleton();

            Type scopeType = typeof(IScope);

#if DEBUG
            DebugLog(assembly, scopeType);
#endif

            services.RegisterAssemblyTypes(assembly)
                .Where(type => scopeType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .AsInterface(i => i.GetInterfaces().Any(c => scopeType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
                .Scope();

            Type transientType = typeof(ITransient);

#if DEBUG
            DebugLog(assembly, transientType);
#endif

            services.RegisterAssemblyTypes(assembly)
                .Where(type => transientType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .AsInterface(i => i.GetInterfaces().Any(c => transientType.IsAssignableFrom(c)) && !_lifetimeTypes.Contains(i))
                .Transient();
        }

        private void DebugLog(Assembly assembly, Type lifetimeType)
        {
            var logger = HostManager.DefaultHost.Services.GetService<ILoggerFactory>().CreateLogger<LifetimeConvention>();

            var scopeTypeList = assembly.GetTypes().Where(type => lifetimeType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);

            if (scopeTypeList.Count() > 0)
            {
                logger.LogDebug($"{assembly.GetName().Name} {lifetimeType.Name} type counts:{scopeTypeList.Count()}");

                foreach (var item in scopeTypeList)
                {
                    var interfacType = item.GetInterfaces().Where(i => !_lifetimeTypes.Contains(i)).FirstOrDefault();

                    if (interfacType == null) continue;

                    var interfaceName = interfacType.Name;

                    if (interfacType.IsGenericType)
                    {
                        interfaceName = interfacType.GetGenericTypeName();
                    }

                    logger.LogDebug($"{lifetimeType.Name} # {item.FullName} ==> {interfaceName}");
                }
            }
        }
    }
}
