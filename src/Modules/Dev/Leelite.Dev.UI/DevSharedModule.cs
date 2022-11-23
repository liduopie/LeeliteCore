using System.IO;

using Leelite.AspNetCore.Modular;
using Leelite.Core.Module;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Leelite.Modules.Dev.UI
{
    public class DevSharedModule : MvcModuleBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(this.GetModuleInfo(app.ApplicationServices).DirectoryPath, "dev_assets")),
                RequestPath = "/dev_assets"
            });
        }
    }
}
