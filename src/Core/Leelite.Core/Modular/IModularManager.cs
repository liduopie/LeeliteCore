using System.Collections.Generic;
using System.Reflection;

using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Core.Module.Store;

namespace Leelite.Core.Modular
{
    public interface IModularManager
    {
        public void Load(HostContext context);

        public IList<ModuleContext> ModuleContexts { get; }

        //IList<ModuleInfo> Infos { get; }

        public IList<IModule> Modules { get; }

        //IList<Assembly> Assemblies { get; }
    }
}
