using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Leelite.Commons.Cache.Lock;

namespace Leelite.Commons.Cache
{
    /// <summary>
    /// 缓存基础接口
    /// </summary>
    public interface ICache : ICacheOptions
    {
        /// <summary>
        /// Unique name of the cache.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 创建一个（分布）锁
        /// </summary>
        /// <param name="resourceName">资源名称</param>
        /// <param name="key">Key标识</param>
        /// <param name="retryCount">重试次数</param>
        /// <param name="retryDelay">重试延时</param>
        /// <returns></returns>
        ICacheLock BeginCacheLock(string resourceName, string key, int retryCount = 0, TimeSpan retryDelay = new TimeSpan());
    }

    /// <summary>
    /// 公共缓存接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface ICache<TKey, TValue> : ICache
    {
        /// <summary>
        /// 获取缓存中最终的键，如Container建议格式： return String.Format("{0}:{1}", "SenparcWeixinContainer", key);
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        string GetFinalKey(string key, bool isFullKey = false);

        /// <summary>
        /// 添加指定ID的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiry">过期时间</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        void Set(TKey key, TValue value, TimeSpan? expiry = null, bool isFullKey = false);

        /// <summary>
        /// 移除指定缓存键的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        void RemoveFromCache(TKey key, bool isFullKey = false);

        /// <summary>
        /// 返回指定缓存键的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        TValue Get(TKey key, bool isFullKey = false);

        /// <summary>
        /// 返回指定缓存键的对象，并强制指定类型
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        T Get<T>(TKey key, bool isFullKey = false);

        /// <summary>
        /// 获取所有缓存信息集合
        /// </summary>
        /// <returns></returns>
        IDictionary<TKey, TValue> GetAll();

        /// <summary>
        /// 检查是否存在Key及对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        bool CheckExisted(TKey key, bool isFullKey = false);

        /// <summary>
        /// 获取缓存集合总数（注意：每个缓存框架的计数对象不一定一致！）
        /// </summary>
        /// <returns></returns>
        long GetCount();

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <param name="expiry">过期时间</param>
        void Update(TKey key, TValue value, TimeSpan? expiry = null, bool isFullKey = false);

        /// <summary>
        /// 【异步方法】添加指定ID的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <param name="expiry">过期时间</param>
        Task SetAsync(TKey key, TValue value, TimeSpan? expiry = null, bool isFullKey = false);

        /// <summary>
        /// 【异步方法】移除指定缓存键的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        Task RemoveFromCacheAsync(TKey key, bool isFullKey = false);

        /// <summary>
        /// 【异步方法】返回指定缓存键的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        Task<TValue> GetAsync(TKey key, bool isFullKey = false);

        /// <summary>
        /// 【异步方法】返回指定缓存键的对象，并强制指定类型
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(TKey key, bool isFullKey = false);

        /// <summary>
        /// 【异步方法】获取所有缓存信息集合
        /// </summary>
        /// <returns></returns>
        Task<IDictionary<TKey, TValue>> GetAllAsync();

        /// <summary>
        /// 【异步方法】检查是否存在Key及对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        Task<bool> CheckExistedAsync(TKey key, bool isFullKey = false);

        /// <summary>
        /// 【异步方法】获取缓存集合总数（注意：每个缓存框架的计数对象不一定一致！）
        /// </summary>
        /// <returns></returns>
        Task<long> GetCountAsync();

        /// <summary>
        /// 【异步方法】更新缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <param name="expiry">过期时间</param>
        Task UpdateAsync(TKey key, TValue value, TimeSpan? expiry = null, bool isFullKey = false);
    }
}
