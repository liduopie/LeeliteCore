using Leelite.Application;
using Leelite.AspNetCore.Modular;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Leelite.Web
{
    public class DevModule : MvcModuleBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var client = new Application.Clients.Client("Dev", "ph-code", "开发管理", "/Dev", "开发管理入口", 1000);

            client.AddNavMenus(new Application.Clients.NavItem("_self", "", "首页", "", "/Dev", "Admin", ""));

            var codeMenus = new Application.Clients.NavItem("_self", "", "代码生成", "", "#", "Admin", "");

            codeMenus.Items.Add(new Application.Clients.NavItem("_self", "", "DDD代码生成器", "", "/Dev/Code", "Admin", ""));
            codeMenus.Items.Add(new Application.Clients.NavItem("_self", "", "项目结构", "", "/Dev/Project", "Admin", ""));

            client.AddNavMenus(codeMenus);

            ApplicationManager.Clients.Add(client);
        }
    }
}
