using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Leelite.FileStorage.UI.Areas.FileStorageHostingStartup))]
namespace Leelite.FileStorage.UI.Areas
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
