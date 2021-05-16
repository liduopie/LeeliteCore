using Leelite.Commons.Host;

namespace Leelite.Core.Module
{
    public abstract class ModuleBase : IModule
    {
        public virtual void ConfigureConventions() { }

        public virtual void ConfigureServices(HostContext context) { }
    }
}
