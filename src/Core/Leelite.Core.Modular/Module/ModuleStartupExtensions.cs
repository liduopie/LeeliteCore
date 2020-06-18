using System;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Modular.Module
{
    public static class ModuleStartupExtensions
    {
        public static ModuleEntry GetModuleEntry(this IModuleStartup startup, IServiceProvider serviceProvider)
        {
            var manager = serviceProvider.GetService<IModularManager>();

            foreach (var entry in manager.ModuleEntries)
            {
                foreach (var assembly in entry.Assemblys)
                {
                    if (assembly.Equals(startup.GetType().Assembly))
                        return entry;
                }
            }

            return null;
        }
    }
}
