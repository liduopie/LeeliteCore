using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Module
{
    public interface IModule
    {
        void ConfigureConventions();
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
