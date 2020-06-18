using System;
using System.IO;
using System.Timers;
using Leelite.Commons.Host;
using Microsoft.Extensions.Logging;

namespace Leelite.Core.Modular
{
    public class HotModule
    {
        private Timer _timer;

        public HotModule()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole()
                    .AddEventLog();
            });
            Logger = loggerFactory.CreateLogger<HotModule>();
        }

        public static ILogger<HotModule> Logger { get; set; }

        public void Run()
        {
            // 添加模块文件夹的文件更新监听
            var watcher = new FileSystemWatcher();

            // 初始化监听
            watcher.BeginInit();
            // 设置监听文件类型
            watcher.Filter = "*.dll";
            // 设置是否监听子目录
            watcher.IncludeSubdirectories = true;
            // 设置是否启用监听?
            watcher.EnableRaisingEvents = true;
            // 设置需要监听的更改类型(如:文件或者文件夹的属性,文件或者文件夹的创建时间;NotifyFilters枚举的内容)
            watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite | NotifyFilters.Size;
            // 设置监听的路径
            watcher.Path = Path.Combine(Directory.GetCurrentDirectory(), ModularOptions.ModulesDirectory);
            // 注册当指定目录的文件或者目录发生改变的时候的监听事件
            watcher.Changed += new FileSystemEventHandler(Watch_Changed);

            //结束初始化
            watcher.EndInit();
        }

        /// <summary>
        /// 当指定目录的文件或者目录发生改变的时候的监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watch_Changed(object sender, FileSystemEventArgs e)
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }

            _timer = new Timer();
            _timer.Interval = 5000;
            _timer.AutoReset = false;
            _timer.Enabled = true;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Logger.LogCritical("Modules Update");

            HostManager.Restart();
        }
    }
}
