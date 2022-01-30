using Leelite.Core.Module;

using McMaster.NETCore.Plugins;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Modular
{
    public interface IModularManager
    {
        public IList<ModuleContext> ModuleContexts { get; }

        public IList<IModule> Modules { get; }

        public void Loading(IServiceCollection services, IConfiguration configuration);

        public IList<PluginLoader> GetLoaders();
    }
}
