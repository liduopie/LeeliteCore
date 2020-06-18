using System;

using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;
using Leelite.Modules.Identity.Models.UserAgg;
using Leelite.Modules.IdentityServer.Contexts;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.IdentityServer.STS
{
    public class IdentityServerSTSModule : MvcModuleStartupBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddIdentityServer(
                option =>
                {
                    option.UserInteraction.LoginUrl = "/Identity/Account/Login";
                    option.UserInteraction.LogoutUrl = "/Identity/Account/Logout";
                }).AddApiAuthorization<User, PersistedGrantContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            // TODO:Uri 修改为配置文件
            services.AddHealthChecks().AddIdentityServer(new Uri("http://localhost:5000"), "Identity Server");
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIdentityServer();
        }
    }
}
