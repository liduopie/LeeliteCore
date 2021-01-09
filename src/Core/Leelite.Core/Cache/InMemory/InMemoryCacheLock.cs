using System;
using System.Collections.Generic;
using System.Threading;

using Leelite.Commons.Cache.Lock;
using Leelite.Commons.Host;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leelite.Core.Cache.InMemory
{
    /// <summary>
    /// 本地锁
    /// </summary>
    public class InMemoryCacheLock : AbstractCacheLock
    {
        private readonly ILogger _logger;

        //这里必须为非公开的构造函数，使用 Create() 方法创建
        public InMemoryCacheLock(InMemoryCache localCache, string resourceName, string key,
            int? retryCount = null, TimeSpan? retryDelay = null)
            : base(localCache, resourceName, key, retryCount ?? 0, retryDelay ?? TimeSpan.FromMilliseconds(10))
        {
            var _loggerFactory = HostManager.Context.HostServices.GetService<ILoggerFactory>();
            _logger = _loggerFactory.CreateLogger<InMemoryCacheLock>();
        }

        /// <summary>
        /// 锁存放容器   TODO：考虑分布式情况
        /// </summary>
        private static Dictionary<string, object> LockPool = new Dictionary<string, object>();
        /// <summary>
        /// 随机数
        /// </summary>
        private static readonly Random _rnd = new Random();
        /// <summary>
        /// 读取LockPool时的锁
        /// </summary>
        private static readonly object lookPoolLock = new object();

        public override ICacheLock Lock()
        {
            int currentRetry = 0;
            int maxRetryDelay = (int)_retryDelay.TotalMilliseconds;
            while (currentRetry++ < _retryCount)
            {
                #region 尝试获得锁

                var getLock = false;
                try
                {
                    lock (lookPoolLock)
                    {
                        if (LockPool.ContainsKey(_resourceName))
                        {
                            getLock = false; //已被别人锁住，没有取得锁
                        }
                        else
                        {
                            LockPool.Add(_resourceName, new object()); //创建锁
                            getLock = true; //取得锁
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("本地同步锁发生异常：" + ex.Message);
                    getLock = false;
                }

                #endregion

                if (getLock)
                {
                    LockSuccessful = true;
                    return this; //取得锁
                }
                Thread.Sleep(_rnd.Next(maxRetryDelay));
            }
            LockSuccessful = false;
            return this;
        }

        public override void UnLock()
        {
            lock (lookPoolLock)
            {
                LockPool.Remove(_resourceName);
            }
        }

        public static ICacheLock CreateAndLock(InMemoryCache cache, string resourceName, string key, int? retryCount = null, TimeSpan? retryDelay = null)
        {
            return new InMemoryCacheLock(cache, resourceName, key, retryCount, retryDelay).Lock();
        }
    }
}
