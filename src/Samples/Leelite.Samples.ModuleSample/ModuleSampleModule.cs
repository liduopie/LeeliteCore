using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Samples.ModuleSample.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Samples.ModuleSample
{
    public class ModuleSampleModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddDbContext<BloggingContext>("Default");
        }
    }
}
