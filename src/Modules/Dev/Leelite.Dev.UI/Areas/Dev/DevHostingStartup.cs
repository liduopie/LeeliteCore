using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Leelite.Modules.Dev.UI.Areas.Identity.DevHostingStartup))]
namespace Leelite.Modules.Dev.UI.Areas.Identity
{
    public class DevHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}