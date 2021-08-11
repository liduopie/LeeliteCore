using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using Leelite.Core.BackgroundJob;
using Leelite.Core.BackgroundJob.Services;
using Leelite.Core.Module;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core
{
    public class CoreModule : ModuleBase
    {
        public override void ConfigureConventions()
        {
            ConventionManager.AddRegistrar(new RecurringJobConvention());
        }

        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddHostedService<JobsService>();
        }
    }
}
