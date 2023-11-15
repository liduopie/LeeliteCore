using Leelite.Application;
using Leelite.AspNetCore.Modular;
using Leelite.Core.Module.Dependency;
using Leelite.FileStorage;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Web
{
    [DependsOn(typeof(FileStorageModule))]
    public class FileStorageUIModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }


        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var client = ApplicationManager.Clients.Find(c => c.Code == "Admin");

            if (client != null)
            {
                client.AddNavMenus(new Application.Clients.NavItem("_self", "ph-files", "文件管理", "", "/Admin/FileStorage/Index", "Admin", ""));
            }
        }

    }
}
