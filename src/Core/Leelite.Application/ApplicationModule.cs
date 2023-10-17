using Leelite.Core.Module;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Application
{
    public class ApplicationModule : ModuleBase
    {
        public override void ConfigureConventions()
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
