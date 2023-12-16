using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Leelite.Web.Areas.FileStorage.FileStorageHostingStartup))]
namespace Leelite.Web.Areas.FileStorage
{
    public class FileStorageHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
