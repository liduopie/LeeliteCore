using Leelite.AspNetCore.Modular;
using Leelite.StaticFiles.Options;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Leelite.StaticFiles
{
    public class StaticFilesModule : MvcModuleBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();

            var staticFilesOptions = new StaticFilesOptions();

            var staticFileConfiguration = configuration.GetSection("StaticFiles");

            staticFileConfiguration.Bind(staticFilesOptions);

            foreach (var item in staticFilesOptions.Paths)
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, item.FilePath)),
                    RequestPath = item.RequestPath
                });
            }
        }
    }
}
