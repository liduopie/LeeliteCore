using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Leelite.Identity.UI.Areas.Identity.IdentityHostingStartup))]
namespace Leelite.Identity.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}