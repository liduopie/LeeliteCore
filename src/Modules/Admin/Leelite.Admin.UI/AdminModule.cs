using Leelite.Application;
using Leelite.AspNetCore.Modular;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Admin.UI
{
    public class AdminModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var client = new Application.Clients.Client("Admin", "ph-squares-four", "后台管理", "/Admin", "系统管理入口", 1);

            ApplicationManager.Clients.Add(client);
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var client = ApplicationManager.Clients.Find(c => c.Code == "Admin");

            if (client != null)
            {
                client.NavMenus.Add(new Application.Clients.NavItem("_self", "ph-dots-three", "仪表盘", "", "", "Admin", ""));
                client.NavMenus.Add(new Application.Clients.NavItem("_self", "ph-chart-pie-slice", "统计分析", "", "/Admin/Home/Dashboard", "Admin", ""));

                client.NavMenus.Add(new Application.Clients.NavItem("_self", "ph-dots-three", "系统", "", "", "Admin", ""));
                client.NavMenus.Add(new Application.Clients.NavItem("_self", "ph-gear", "系统设置", "", "/Admin/Settings/Index", "Admin", ""));
            }
        }
    }
}
