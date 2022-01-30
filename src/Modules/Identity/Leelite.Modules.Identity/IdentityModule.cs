using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Framework;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.RoleAgg;
using Leelite.Modules.Identity.Models.UserAgg;
using Leelite.Modules.Identity.Stores.RoleStore;
using Leelite.Modules.Identity.Stores.UserStore;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Leelite.Modules.Identity
{
    [DependsOn(typeof(FrameworkModule))]
    public class IdentityModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>("Identity");

            services.TryAddScoped<IUserStore<User>, UserStore>();
            services.TryAddScoped<IRoleStore<Role>, RoleStore>();

            services.AddHealthChecks().AddDbContextCheck<IdentityContext>(tags: new[] { "database" });
        }
    }
}
