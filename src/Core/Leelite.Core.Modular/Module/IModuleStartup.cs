using System.Threading.Tasks;

using Leelite.Commons.Host;

namespace Leelite.Core.Modular.Module
{
    public interface IModuleStartup
    {
        void ConfigureConventions();

        void ConfigureServices(HostContext context);

        Task UpdateDatabase();
    }
}
