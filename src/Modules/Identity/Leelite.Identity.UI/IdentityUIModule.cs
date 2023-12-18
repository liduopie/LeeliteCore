using Leelite.Application;
using Leelite.AspNetCore.Modular;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Identity.Models.RoleAgg;
using Leelite.Identity.Models.UserAgg;
using Leelite.Web.Areas.Identity.Services;
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
using Leelite.Identity;
using Leelite.Identity.Contexts;

namespace Leelite.Web
{
    [DependsOn(typeof(IdentityModule), typeof(SettingsModule))]
    public class IdentityUIModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentity<User, Role>(o =>
                {
                    o.Stores.MaxLengthForKeys = 256;
                })
                .AddDefaultTokenProviders();

            var authenticationConfig = configuration.GetSection("Authentication");

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                authenticationConfig.Bind(nameof(IdentityOptions), options);
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;

                authenticationConfig.Bind(nameof(CookieAuthenticationOptions), options);
            });

            var authBuilder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    authenticationConfig.Bind(nameof(JwtBearerOptions), options);
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    authenticationConfig.Bind(nameof(CookieAuthenticationOptions), options);
                });

            var externalLogins = authenticationConfig.GetSection("ExternalLogins");

            if (externalLogins.GetSection("MicrosoftAccount").Exists())
            {
                authBuilder.AddMicrosoftAccount(options => externalLogins.Bind("MicrosoftAccount", options));
            }

            services.TryAddTransient<IEmailSender, EmailSender>();

            services.AddHealthChecks().AddDbContextCheck<IdentityContext>(tags: new[] { "database" });

            var client = new Application.Clients.Client("Identity", "ph-user", "用户信息", "/Identity/Manage", "用户信息", -1);

            ApplicationManager.Clients.Add(client);
        }


        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(this.GetModuleInfo(app.ApplicationServices).DirectoryPath, "wwwroot")),
                RequestPath = "/identity"
            });

            var client = ApplicationManager.Clients.Find(c => c.Code == "Identity");

            if (client != null)
            {
                client.AddNavMenus(new Application.Clients.NavItem("_self", "ph-user-circle", "我的资料", "", "/Identity/Manage/Index", sort: 0));
                client.AddNavMenus(new Application.Clients.NavItem("_self", "ph-envelope-simple", "邮箱", "", "/Identity/Manage/Email", sort: 0));
                client.AddNavMenus(new Application.Clients.NavItem("_self", "ph-password", "密码", "", "/Identity/Manage/ChangePassword", sort: 0));
                client.AddNavMenus(new Application.Clients.NavItem("_self", "ph-codesandbox-logo", "扩展登录", "", "/Identity/Manage/ExternalLogins", sort: 0));
                client.AddNavMenus(new Application.Clients.NavItem("_self", "ph-line-segment", "双因子", "", "/Identity/Manage/TwoFactorAuthentication", sort: 0));
                client.AddNavMenus(new Application.Clients.NavItem("_self", "ph-database", "个人数据", "", "/Identity/Manage/PersonalData", sort: 0));
                client.AddNavMenus(new Application.Clients.NavItem("_self", "", "", "", "", sort: 0));
            }
        }

    }
}
