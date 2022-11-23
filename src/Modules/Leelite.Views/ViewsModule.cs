using Leelite.AspNetCore.Modular;
using Leelite.Core.Module;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Leelite.UI.Shared
{
    public class UISharedModule : MvcModuleBase
    {

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(this.GetModuleInfo(app.ApplicationServices).DirectoryPath, "wwwroot")),
                RequestPath = "/assets"
            });
        }
    }
}
