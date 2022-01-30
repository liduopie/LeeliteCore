using System.IO;

using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Modules.Identity.Models.RoleAgg;
using Leelite.Modules.Identity.Models.UserAgg;
using Leelite.Modules.Identity.UI.Areas.Identity.Services;
using Leelite.Modules.Settings;

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

namespace Leelite.Modules.Identity.UI
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

            services.Configure<IdentityOptions>(options => configuration.Bind(nameof(IdentityOptions), options));
            services.ConfigureApplicationCookie(options => configuration.Bind(nameof(CookieAuthenticationOptions), options));

            var externalLogins = configuration.GetSection("ExternalLogins");

            var authBuilder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => configuration.Bind("JwtSettings", options))
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => configuration.Bind("CookieSettings", options));

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
