using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Leelite.Core.Module.Store;

namespace Leelite.Core.Modular
{
    public class ModuleContext
    {
        public ModuleInfo Info { get; set; }

        public IList<Assembly> Assemblies { get; set; } = new List<Assembly>();

        public IDisposable Loader { get; set; }
    }
}
