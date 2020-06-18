using System.Collections.Generic;
using Leelite.Commons.Host;
using Leelite.Core.Modular.Module;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Modular
{
    public interface IModularManager
    {
        IList<ModuleEntry> ModuleEntries { get; }

        IList<IModuleStartup> ModuleStartups { get; }

        void Load();

        void ConfigureServices(HostContext context);
    }
}
