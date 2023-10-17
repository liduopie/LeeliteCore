using Leelite.Application;
using Leelite.AspNetCore.Modular;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Leelite.Modules.Dev.UI
{
    public class HomeModule : MvcModuleBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var client = new Application.Clients.Client("Home", "ph-house", "主页入口", "/", "默认主页", -1);

            ApplicationManager.Clients.Add(client);
        }
    }
}
