using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Leelite.Web.Areas.Identity.IdentityHostingStartup))]
namespace Leelite.Web.Areas.Identity
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