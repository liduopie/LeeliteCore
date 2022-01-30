using Leelite.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Leelite.AspNetCore.Host
{
    public static class HostManager
    {
        private static bool _running;

        static HostManager()
        {
            _running = false;
            Restarting = false;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            Logger = loggerFactory.CreateLogger("HostManager");
        }

        public static WebApplication App { get; set; }

        public static bool Restarting { get; private set; }

        private static ILogger Logger { get; set; }

        public static void Start(string[] args)
        {
            if (_running)
                return;

            _running = true;

            Logger.LogCritical("Host Starting...");

            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            if (builder.Environment.IsDevelopment())
            {
                Logger.LogInformation($"Running in development.");
            }

            // 主机配置
            builder.Host.ConfigureHost();

            // 框架配置
            builder.Services.ConfigureLeeliteCore(configuration);

            // start 相关
            builder.Services.AddSharedConnection();
            builder.Services.AddLeeliteWebCore(configuration);

            App = builder.Build();

            App.UseLeeliteWebCore(App.Environment);

            App.Run();
        }

        public static void Stop()
        {
            if (!_running)
                return;

            _running = false;

            Logger.LogCritical("Host Stop...");

            App.StopAsync();
        }

        public static void Restart()
        {
            Logger.LogCritical("Host Restart...");

            Restarting = true;

            Stop();
        }
    }
}
