using System;

using Leelite.Commons.Host;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AppHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                do
                {
                    HostManager.Start(args, builder =>
                    {
                        builder
                        .ConfigureLeeliteWebCore()
                        .ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.UseStartup<Startup>();
                        });
                    });
                } while (HostManager.Restarting);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
