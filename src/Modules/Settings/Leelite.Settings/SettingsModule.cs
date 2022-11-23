using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Framework;
using Leelite.Settings.Contexts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Settings
{
    [DependsOn(typeof(FrameworkModule))]
    public class SettingsModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SettingsContext>("Default");
        }
    }
}
