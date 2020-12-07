using IdentityModel;

using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Modules.IdentityServer.Admin.Api.Configuration;
using Leelite.Modules.IdentityServer.Admin.Api.Configuration.Constants;
using Leelite.Modules.IdentityServer.Admin.Api.ExceptionHandling;
using Leelite.Modules.IdentityServer.Admin.Api.Resources;
using Leelite.Modules.IdentityServer.Admin.Contexts;
using Leelite.Modules.IdentityServer.Contexts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Skoruba.AuditLogging.EntityFramework.Entities;

namespace Leelite.Modules.IdentityServer.Admin.Api
{
    public class IdentityServerAdminApiModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            IConfiguration configuration = context.HostServices.GetService<IConfiguration>();

            var identityConfiguration = configuration.GetSection("IdentityServer");

            var adminApiConfiguration = identityConfiguration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();

            services.AddSingleton(adminApiConfiguration);

            services.AddScoped<ControllerExceptionFilterAttribute>();
            services.AddScoped<IApiErrorResources, ApiErrorResources>();

            // Add authorization services
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationConsts.AdministrationPolicy,
                    policy =>
                        policy.RequireAssertion(context => context.User.HasClaim(c =>
                                (c.Type == JwtClaimTypes.Role && c.Value == adminApiConfiguration.AdministrationRole) ||
                                (c.Type == $"client_{JwtClaimTypes.Role}" && c.Value == adminApiConfiguration.AdministrationRole)
                            )
                        ));
            });

            services.AddAdminServices<ConfigurationContext, PersistedGrantContext, AdminLogContext>();

            services.AddAdminApiCors(adminApiConfiguration);

            services.AddAuditEventLogging<AdminAuditLogContext, AuditLog>(identityConfiguration);

        }
    }
}
