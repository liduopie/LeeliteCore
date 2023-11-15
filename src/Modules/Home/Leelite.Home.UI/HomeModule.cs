using Leelite.Application;
using Leelite.AspNetCore.Modular;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Leelite.Home.UI
{
    public class HomeModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var client = new Application.Clients.Client("Home", "ph-house", "主页", "/", "主页", -1);

            ApplicationManager.Clients.Add(client);
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var client = ApplicationManager.Clients.Find(c => c.Code == "Home");

            if (client != null)
            {
                client.AddNavMenus(new Application.Clients.NavItem("_self", "", "主页", "", "/Home", sort: 0));
            }
        }
    }
}
