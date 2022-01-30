using Leelite.Commons.Convention;
using Leelite.Core.BackgroundJob;
using Leelite.Core.BackgroundJob.Services;
using Leelite.Core.Module;
using Leelite.Core.Settings;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core
{
    public class CoreModule : ModuleBase
    {
        public override void ConfigureConventions()
        {
            ConventionManager.AddRegistrar(new RecurringJobConvention());
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<ISettingManager, InMemorySettingManager>();
            //services.AddHostedService<JobsService>();
        }
    }
}
