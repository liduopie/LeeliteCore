using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using Leelite.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;
using System.Reflection;

namespace Leelite.Core.BackgroundJob
{
    /// <summary>
    /// 定时任务依赖注入约定
    /// </summary>
    public class RecurringJobConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            var builder = HostManager.Context.ServiceDescriptors;

            Type jobType = typeof(IRecurringJob);

            var types = assembly.GetTypes().Where(type => jobType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract).ToList();

            builder.RegisterAssemblyTypes(assembly)
               .Where(type => jobType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
               .AsInterface()
               .AsSelf()
               .Scope();
        }
    }
}
