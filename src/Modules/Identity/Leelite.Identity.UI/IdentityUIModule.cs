using Leelite.AspNetCore.Modular;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Identity.Models.RoleAgg;
using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.UI.Areas.Identity.Services;
using Leelite.Settings;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;

namespace Leelite.Identity.UI
{
    [DependsOn(typeof(IdentityModule), typeof(SettingsModule))]
    public class IdentityUIModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>(o =>
            {
                o.Stores.MaxLengthForKeys = 256;
            }).AddDefaultTokenProviders();

            var authenticationConfig = configuration.GetSection("Authentication");

            services.Configure<IdentityOptions>(options => authenticationConfig.Bind(nameof(IdentityOptions), options));
            services.ConfigureApplicationCookie(options => authenticationConfig.Bind(nameof(CookieAuthenticationOptions), options));

            var authBuilder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => authenticationConfig.Bind(nameof(JwtBearerOptions), options))
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => authenticationConfig.Bind(nameof(CookieAuthenticationOptions), options));

            var externalLogins = authenticationConfig.GetSection("ExternalLogins");

            if (externalLogins.GetSection("MicrosoftAccount").Exists())
            {
                authBuilder.AddMicrosoftAccount(options => externalLogins.Bind("MicrosoftAccount", options));
            }

            services.TryAddTransient<IEmailSender, EmailSender>();
        }


        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(this.GetModuleInfo(app.ApplicationServices).DirectoryPath, "wwwroot")),
                RequestPath = "/identity"
            });
        }

    }
}
