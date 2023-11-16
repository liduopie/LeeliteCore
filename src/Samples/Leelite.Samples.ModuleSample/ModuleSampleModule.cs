using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Samples.ModuleSample.Contexts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Samples.ModuleSample
{
    public class ModuleSampleModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloggingContext>("Default");
        }
    }
}
