using Leelite.Core.Module.Store;

using McMaster.NETCore.Plugins;

using System.Reflection;

namespace Leelite.Core.Modular
{
    public class ModuleContext
    {
        public ModuleInfo Info { get; set; }

        public IList<Assembly> Assemblies { get; set; } = new List<Assembly>();

        public PluginLoader Loader { get; set; }
    }
}
