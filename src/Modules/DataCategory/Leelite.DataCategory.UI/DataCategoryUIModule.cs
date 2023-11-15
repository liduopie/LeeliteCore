using Leelite.Application;
using Leelite.Application.Clients;
using Leelite.AspNetCore.Modular;
using Leelite.Core.Module;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Leelite.Web
{
    public class DataCategoryUIModule : MvcModuleBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(this.GetModuleInfo(app.ApplicationServices).DirectoryPath, "wwwroot")),
                RequestPath = "/admin"
            });

            var admin = ApplicationManager.Clients.Find(c => c.Code == "Admin");

            if (admin != null)
            {
                admin.AddNavMenus(new NavItem("_self", "ph-tree-structure", "数据分类", "", "/Admin/DataCategory/Index", "Admin", ""));
            }
        }
    }
}
