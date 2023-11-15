using Leelite.Application;
using Leelite.AspNetCore.Modular;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Leelite.Web
{

    public class AreaModule : MvcModuleBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var client = ApplicationManager.Clients.Find(c => c.Code == "Admin");

            if (client != null)
            {
                client.AddNavMenus(new Application.Clients.NavItem("_self", "ph-map-trifold", "区域管理", "", "/Admin/Area/Index", "Admin", ""));
            }
        }
    }
}
