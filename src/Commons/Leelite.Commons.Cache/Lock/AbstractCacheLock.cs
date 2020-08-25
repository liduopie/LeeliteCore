using System;
using System.Threading.Tasks;

namespace Leelite.Commons.Cache.Lock
{
    public abstract class AbstractCacheLock : ICacheLock
    {
        protected string _resourceName;
        protected ICache _cache;
        protected int _retryCount;
        protected TimeSpan _retryDelay;

        public bool LockSuccessful { get; set; }

        /// <summary>
        /// 默认重试次数
        /// </summary>
        public readonly int DefaultRetryCount = 20;

        /// <summary>
        /// 默认每次重试间隔时间
        /// </summary>
        public readonly TimeSpan DefaultRetryDelay = TimeSpan.FromMilliseconds(10);

        protected AbstractCacheLock(ICache cache, string resourceName, string key, int? retryCount, TimeSpan? retryDelay)
        {
            _cache = cache;
            _resourceName = resourceName + key; /*加上Key可以针对某个AppId加锁*/
            _retryCount = retryCount == null || retryCount == 0 ? DefaultRetryCount : retryCount.Value;
            _retryDelay = retryDelay == null || retryDelay.Value.TotalMilliseconds == 0 ? DefaultRetryDelay : retryDelay.Value;
        }




        /// <inheritdoc />
        public double GetTotalTtl(int retryCount, TimeSpan retryDelay)
        {
            return retryDelay.TotalMilliseconds * retryCount;
        }

        /// <inheritdoc />
        public abstract ICacheLock Lock();

        /// <inheritdoc />
        public abstract void UnLock();

        public void Dispose()
        {
            //必须为true
            Dispose(true);
            //通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
        }

        //<summary>
        /// 必须，以备程序员忘记了显式调用Dispose方法
        ///</summary>
        ~AbstractCacheLock()
        {
            //必须为false
            Dispose(false);
        }

        protected bool disposed = false;

        ///<summary>
        /// 非密封类修饰用protected virtual
        /// 密封类修饰用private
        ///</summary>
        ///<param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            UnLock();

            if (disposing)
            {
                //清理托管资源
            }

            //让类型知道自己已经被释放
            disposed = true;
        }

    }
}
