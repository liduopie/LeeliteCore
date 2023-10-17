using Leelite.Application;
using Leelite.AspNetCore.Modular;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Leelite API", Version = "v1" });
            });
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leelite API V1");
            });

            var client = ApplicationManager.Clients.Find(c => c.Code == "Admin");

            if (client != null)
            {
                client.Shortcuts.Add(new Application.Clients.NavItem("_blank", "/global_assets/images/logos/1.svg", "Swagger", "API 帮助文档", "/swagger", "Admin", ""));
            }
        }
    }
}
