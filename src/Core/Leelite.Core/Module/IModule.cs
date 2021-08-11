using Leelite.Commons.Host;

namespace Leelite.Core.Module
{
    public interface IModule
    {
        void ConfigureConventions();
        void ConfigureServices(HostContext context);
    }
}
