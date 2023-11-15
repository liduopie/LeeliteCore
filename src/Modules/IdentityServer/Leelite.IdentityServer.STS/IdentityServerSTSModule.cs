using Leelite.Application;
using Leelite.AspNetCore.Modular;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Identity;
using Leelite.Identity.Models.RoleAgg;
using Leelite.Identity.Models.UserAgg;
using Leelite.IdentityServer;
using Leelite.IdentityServer.Contexts;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Leelite.IdentityServer.STS
{
    [DependsOn(typeof(IdentityModule))]
    [DependsOn(typeof(IdentityServerModule))]
    public class IdentityServerSTSModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentity<User, Role>(o =>
                {
                    o.Stores.MaxLengthForKeys = 256;
                })
                .AddDefaultTokenProviders();

            services
               .AddIdentityServer(options =>
               {
                   //options.Events.RaiseErrorEvents = true;
                   //options.Events.RaiseInformationEvents = true;
                   //options.Events.RaiseFailureEvents = true;
                   //options.Events.RaiseSuccessEvents = true;

                   // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                   options.EmitStaticAudienceClaim = true;

                   options.UserInteraction.LoginUrl = "/Identity/Account/Login";
                   options.UserInteraction.LogoutUrl = "/Identity/Account/Logout";
               })
               .AddConfigurationStore(options =>
                {
                    options.ResolveDbContextOptions = (serviceProvider, builder) =>
                    {
                        builder.UseDbProvider<ConfigurationContext>(serviceProvider, "IdentityServer");
                    };
                })
               .AddOperationalStore(options =>
               {
                   options.ResolveDbContextOptions = (serviceProvider, builder) =>
                   {
                       builder.UseDbProvider<PersistedGrantContext>(serviceProvider, "IdentityServer");
                   };
               }).AddAspNetIdentity<User>();

            services.AddDataProtection().PersistKeysToDbContext<DataProtectionDbContext>();

            // TODO:Uri 修改为配置文件
            // services.AddHealthChecks().AddIdentityServer(new Uri("http://localhost:5000"), "Identity Server");
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIdentityServer();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(this.GetModuleInfo(app.ApplicationServices).DirectoryPath, "wwwroot")),
                RequestPath = "/identity"
            });

            var client = ApplicationManager.Clients.Find(c => c.Code == "Admin");

            if (client != null)
            {
                client.Shortcuts.Add(new Application.Clients.NavItem("_blank", "/global_assets/images/logos/3.svg", "IdentityServer", "认证服务", "/Identity/Index", "Admin", ""));
            }
        }
    }
}
