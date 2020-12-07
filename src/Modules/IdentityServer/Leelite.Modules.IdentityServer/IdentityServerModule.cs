using IdentityServer4.EntityFramework.Storage;

using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Modules.IdentityServer.Contexts;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.IdentityServer
{
    public class IdentityServerModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddDbContext<PersistedGrantContext>("IdentityServer");
            services.AddDbContext<ConfigurationContext>("IdentityServer");
            services.AddDbContext<DataProtectionDbContext>("IdentityServer");
            services.AddConfigurationDbContext();
            services.AddOperationalDbContext();

            services.AddHealthChecks().AddDbContextCheck<PersistedGrantContext>(nameof(PersistedGrantContext), tags: new[] { "database" });
            services.AddHealthChecks().AddDbContextCheck<ConfigurationContext>(nameof(ConfigurationContext), tags: new[] { "database" });
        }
    }
}
