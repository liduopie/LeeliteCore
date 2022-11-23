using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Framework;
using Leelite.Identity.Contexts;
using Leelite.Identity.Models.RoleAgg;
using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.Stores.RoleStore;
using Leelite.Identity.Stores.UserStore;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Leelite.Identity
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
