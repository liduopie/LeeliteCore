using System.Threading.Tasks;

using Leelite.Commons.Host;
using Leelite.Core.Modular.Dependency;
using Leelite.Core.Modular.Module;
using Leelite.Framework;
using Leelite.Modules.Settings.Contexts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.Settings
{
    [DependsOn(typeof(FrameworkModule))]
    public class SettingsModule : ModuleStartupBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddDbContext<SettingsContext>("Default");
        }

        public override async Task UpdateDatabase()
        {
            var settingsContext = HostManager.Context.HostServices.GetService<SettingsContext>();

            await settingsContext.Database.MigrateAsync();
        }
    }
}
