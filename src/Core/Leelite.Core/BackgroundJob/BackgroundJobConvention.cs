using System.Reflection;

using Leelite.Commons.Convention;
using Leelite.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.BackgroundJob
{
    public class BackgroundJobConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly, IServiceCollection services)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            Type jobType = typeof(IBackgroundJob);

            var types = assembly.GetTypes().Where(type => jobType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract).ToList();

            services.RegisterAssemblyTypes(assembly)
               .Where(type => jobType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
               .AsInterface()
               .AsSelf()
               .Scope();
        }
    }
}
