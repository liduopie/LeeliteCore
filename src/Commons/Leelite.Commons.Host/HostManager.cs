using System;

namespace Leelite.Commons.Host
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public static class HostManager
    {

        private static bool _running;

        static HostManager()
        {
            _running = false;
            Context = new HostContext();
            Restarting = false;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            Logger = loggerFactory.CreateLogger("HostManager");
        }

        public static HostContext Context { get; private set; }

        public static ILogger Logger { get; set; }

        public static bool Restarting { get; private set; }

        public static void Start(string[] args, Action<IHostBuilder> configure)
        {
            if (_running)
                return;

            _running = true;

            Logger.LogCritical("Host Starting");

            var _hostBuilder = Host.CreateDefaultBuilder(args).ConfigureHost();

            configure(_hostBuilder);

            Context.Host = _hostBuilder.Build();

            Context.Host.Run();
        }

        public static void Stop()
        {
            if (!_running)
                return;

            _running = false;

            Logger.LogCritical("Host Stop");

            Context.Host.StopAsync();
        }

        public static void Restart()
        {
            Restarting = true;

            Stop();
        }
    }
}
