using System;

using Leelite.Core.Modular;
using Leelite.Core.Module.Store;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Module
{
    public static class ModuleExtensions
    {
        public static ModuleInfo GetModuleInfo(this IModule module, IServiceProvider serviceProvider)
        {
            var manager = serviceProvider.GetService<IModularManager>();

            foreach (var context in manager.ModuleContexts)
            {
                foreach (var assembly in context.Assemblies)
                {
                    var moduleAssemblyName = module.GetType().Assembly.GetName().Name;

                    if (assembly.GetName().Name == moduleAssemblyName) return context.Info;
                }
            }

            return null;
        }
    }
}
