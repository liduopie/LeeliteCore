using Leelite.Core.Module;
using Leelite.IdentityServer.Contexts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.IdentityServer
{
    public class IdentityServerModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConfigurationContext>("IdentityServer");
            services.AddDbContext<PersistedGrantContext>("IdentityServer");
            // Save data protection keys to db, using a common application name shared between Admin and STS
            services.AddDbContext<DataProtectionDbContext>("IdentityServer");

            services.AddHealthChecks().AddDbContextCheck<ConfigurationContext>(nameof(ConfigurationContext), tags: new[] { "database" });
            services.AddHealthChecks().AddDbContextCheck<PersistedGrantContext>(nameof(PersistedGrantContext), tags: new[] { "database" });
            services.AddHealthChecks().AddDbContextCheck<DataProtectionDbContext>(nameof(DataProtectionDbContext), tags: new[] { "database" });
        }
    }
}
