using System.Threading.Tasks;

using Leelite.Commons.Host;

namespace Leelite.Core.Modular.Module
{
    public abstract class ModuleStartupBase : IModuleStartup
    {
        public virtual void ConfigureConventions() { }

        public virtual void ConfigureServices(HostContext context) { }

        public virtual Task UpdateDatabase()
        {
            return Task.CompletedTask;
        }
    }
}
