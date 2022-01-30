using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Module
{
    public abstract class ModuleBase : IModule
    {
        public virtual void ConfigureConventions() { }

        public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration) { }
    }
}
