using System.Collections.Generic;
using System.Reflection;

namespace Leelite.Core.Modular.Module
{
    public class ModuleEntry
    {
        public ModuleEntry(ModuleInfo info)
        {
            ModuleName = info.Name;
            ModulePath = info.Path;
        }

        public string ModuleName { get; set; }

        public string ModulePath { get; set; }

        public IList<Assembly> Assemblys { get; set; } = new List<Assembly>();

        public IList<Assembly> ViewAssemblys { get; set; } = new List<Assembly>();

    }
}
