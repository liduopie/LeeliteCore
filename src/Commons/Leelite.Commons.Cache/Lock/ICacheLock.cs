using System;
using System.Threading.Tasks;

namespace Leelite.Commons.Cache.Lock
{
    /// <summary>
    /// 缓存锁接口
    /// </summary>
    public interface ICacheLock : IDisposable
    {
        /// <summary>
        /// 是否成功获得锁
        /// </summary>
        bool LockSuccessful { get; set; }

        /// <summary>
        /// 获取最长锁定时间（锁最长生命周期）
        /// </summary>
        /// <param name="retryCount">重试次数，</param>
        /// <param name="retryDelay">最小锁定时间周期</param>
        /// <returns>单位：Milliseconds，毫秒</returns>
        double GetTotalTtl(int retryCount, TimeSpan retryDelay);

        /// <summary>
        /// 开始锁
        /// </summary>
        ICacheLock Lock();

        /// <summary>
        /// 释放锁
        /// </summary>
        void UnLock();
    }
}
