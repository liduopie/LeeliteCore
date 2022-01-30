using Leelite.Commons.Convention;
using Leelite.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Leelite.Core.BackgroundJob
{
    /// <summary>
    /// 定时任务依赖注入约定
    /// </summary>
    public class RecurringJobConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly, IServiceCollection services)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            Type jobType = typeof(IRecurringJob);

            var types = assembly.GetTypes().Where(type => jobType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract).ToList();

            services.RegisterAssemblyTypes(assembly)
               .Where(type => jobType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
               .AsInterface()
               .AsSelf()
               .Scope();
        }
    }
}
