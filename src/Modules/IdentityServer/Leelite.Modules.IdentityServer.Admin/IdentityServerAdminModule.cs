using Leelite.Commons.Host;
using Leelite.Core.Modular.Module;
using Leelite.Modules.IdentityServer.Admin.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.IdentityServer.Admin
{
    public class IdentityServerAdminModule : ModuleStartupBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddDbContext<AdminIdentityContext>("Identity");
            services.AddDbContext<AdminLogContext>("IdentityServerAdmin");
            services.AddDbContext<AdminAuditLogContext>("IdentityServerAdmin");

            services.AddHealthChecks().AddDbContextCheck<AdminIdentityContext>(nameof(AdminIdentityContext), tags: new[] { "database" });
            services.AddHealthChecks().AddDbContextCheck<AdminLogContext>(nameof(AdminLogContext), tags: new[] { "database" });
            services.AddHealthChecks().AddDbContextCheck<AdminAuditLogContext>(nameof(AdminAuditLogContext), tags: new[] { "database" });
        }
    }
}
