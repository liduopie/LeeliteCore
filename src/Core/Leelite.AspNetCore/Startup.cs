using Leelite.Commons.Host;
using Leelite.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Leelite.AspNetCore
{
    public static class Startup
    {
        private static bool _running;
        private static ILogger Logger { get; set; }
        public static bool Stoped { get; private set; }
        public static WebApplication App { get; set; }

        static Startup()
        {
            _running = false;
            Stoped = false;

            HostManager.DefaultHost = Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(config =>
                {
                    config.AddEnvironmentVariables(prefix: "ASPNETCORE_");
                })
                .Build();

            Logger = HostManager.DefaultHost.Services.GetService<ILoggerFactory>().CreateLogger("Startup");
        }

        public static void Run(string[] args)
        {
            try
            {
                do
                {
                    if (_running)
                        return;

                    _running = true;

                    var builder = WebApplication.CreateBuilder(args);

                    var configuration = builder.Configuration;

                    // 框架配置
                    builder.Services.ConfigureLeeliteCore(configuration);

                    // start 相关
                    builder.Services.AddLeeliteWebCore(configuration);

                    // 数据库开发页面
                    // builder.Services.AddDatabaseDeveloperPageExceptionFilter();

                    App = builder.Build();

                    HostManager.WebApplication = App;

                    App.UseLeeliteWebCore(App.Environment);

                    App.Run();

                } while (!Stoped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.Message}");
                throw;
            }
        }

        public static void Stop()
        {
            if (!_running)
                return;

            _running = false;

            Stoped = true;

            Logger.LogCritical("Host Stop...");

            App.StopAsync();
        }

        public static void Restart()
        {
            Logger.LogCritical("Host Restart...");

            Stop();
        }
    }
}
