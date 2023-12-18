using Leelite.Application;
using Leelite.AspNetCore.Modular;

using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Leelite.Swagger
{
    public class SwaggerModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("base", new OpenApiInfo { Title = "Admin API", Version = "v1" });
                c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["area"]}_{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

                c.SwaggerDoc("platform", new OpenApiInfo { Title = "Manager API", Version = "v1" });
                c.SwaggerDoc("user", new OpenApiInfo { Title = "User API", Version = "v1" });
                c.SwaggerDoc("web", new OpenApiInfo { Title = "Web API", Version = "v1" });
            });

            // Adds FluentValidationRules staff to Swagger. (Minimal configuration)
            services.AddFluentValidationRulesToSwagger();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/base/swagger.json", "Admin API V1");
                c.SwaggerEndpoint("/swagger/platform/swagger.json", "Manager API V1");
                c.SwaggerEndpoint("/swagger/user/swagger.json", "User API V1");
                c.SwaggerEndpoint("/swagger/web/swagger.json", "Web API V1");
            });

            app.UseReDoc(c =>
            {
                // c.RoutePrefix = "docs";
                c.SpecUrl("/swagger/user/swagger.json");
                c.DocumentTitle = "User API";
            });

            var client = ApplicationManager.Clients.Find(c => c.Code == "Admin");

            if (client != null)
            {
                client.Shortcuts.Add(new Application.Clients.NavItem("_blank", "/global_assets/images/logos/1.svg", "Swagger", "调试API 帮助文档", "/swagger", "Admin", ""));
                client.Shortcuts.Add(new Application.Clients.NavItem("_blank", "/global_assets/images/logos/1.svg", "ReDoc", "开发API 帮助文档", "/api-docs", "Admin", ""));
            }
        }
    }
}
