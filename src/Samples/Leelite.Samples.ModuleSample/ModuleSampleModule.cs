using Leelite.Commons.Host;
using Leelite.Core.Modular.Module;
using Leelite.Samples.ModuleSample.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Samples.ModuleSample
{
    public class ModuleSampleModule : ModuleStartupBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddDbContext<BloggingContext>("Default");
        }
    }
}
