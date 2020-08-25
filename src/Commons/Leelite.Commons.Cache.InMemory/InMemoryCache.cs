using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Leelite.Commons.Cache.BaseCache;
using Leelite.Commons.Cache.Lock;
using Leelite.Commons.Host;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Commons.Cache.InMemory
{
    public class InMemoryCache : IBaseCache
    {
        private const string KEY_STORE_KEY = "KEY_STORE";
        private const string DEFAULT_CACHE = "DEFAULT_CACHE";

        private IMemoryCache _cache;

        public string Name { get; set; }

        public TimeSpan DefaultSlidingExpireTime { get; set; }
        public TimeSpan? DefaultAbsoluteExpireTime { get; set; }

        public InMemoryCache()
        {
            _cache = HostManager.Context.HostServices.GetService<IMemoryCache>();
        }

        public ICacheLock BeginCacheLock(string resourceName, string key, int retryCount = 0, TimeSpan retryDelay = default)
        {
            return InMemoryCacheLock.CreateAndLock(this, resourceName, key, retryCount, retryDelay);
        }

        public bool CheckExisted(string key, bool isFullKey = false)
        {
            var cacheKey = GetFinalKey(key, isFullKey);

            return _cache.Get(cacheKey) != null;
        }

        public async Task<bool> CheckExistedAsync(string key, bool isFullKey = false)
        {
            return await Task.Factory.StartNew(() => CheckExisted(key, isFullKey)).ConfigureAwait(false);
        }

        public object Get(string key, bool isFullKey = false)
        {
            if (string.IsNullOrEmpty(key)) return null;

            if (!CheckExisted(key, isFullKey)) return null;

            var cacheKey = GetFinalKey(key, isFullKey);

            return _cache.Get(cacheKey);
        }

        public T Get<T>(string key, bool isFullKey = false)
        {
            if (string.IsNullOrEmpty(key)) return default;

            if (!CheckExisted(key, isFullKey)) return default;

            var cacheKey = GetFinalKey(key, isFullKey);

            return _cache.Get<T>(cacheKey);
        }

        public IDictionary<string, object> GetAll()
        {
            IDictionary<string, object> data = new Dictionary<string, object>();

            //获取所有Key
            var keyStoreFinalKey = GetFinalKey(KEY_STORE_KEY);

            if (CheckExisted(keyStoreFinalKey, true))
            {
                var keys = _cache.Get<List<string>>(keyStoreFinalKey);
                foreach (var key in keys)
                {
                    data[key] = Get(key, true);
                }
            }

            return data;
        }

        public async Task<IDictionary<string, object>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() => GetAll()).ConfigureAwait(false);
        }

        public async Task<object> GetAsync(string key, bool isFullKey = false)
        {
            return await Task.Factory.StartNew(() => Get(key, isFullKey)).ConfigureAwait(false);
        }

        public async Task<T> GetAsync<T>(string key, bool isFullKey = false)
        {
            return await Task.Factory.StartNew(() => Get<T>(key, isFullKey)).ConfigureAwait(false);
        }

        public long GetCount()
        {
            var keyStoreFinalKey = GetFinalKey(KEY_STORE_KEY);

            if (CheckExisted(keyStoreFinalKey, true))
            {
                var keys = _cache.Get<List<string>>(keyStoreFinalKey);
                return keys.Count;
            }
            else
            {
                return 0;
            }
        }

        public async Task<long> GetCountAsync()
        {
            return await Task.Factory.StartNew(() => GetCount()).ConfigureAwait(false);
        }

        public string GetFinalKey(string key, bool isFullKey = false)
        {
            return isFullKey ? key : $"Leelite:{DEFAULT_CACHE}:{key}";
        }

        public void RemoveFromCache(string key, bool isFullKey = false)
        {
            var cacheKey = GetFinalKey(key, isFullKey);
            _cache.Remove(cacheKey);

            //移除key
            var keyStoreFinalKey = GetFinalKey(KEY_STORE_KEY);

            if (CheckExisted(keyStoreFinalKey, true))
            {
                var keys = _cache.Get<List<string>>(keyStoreFinalKey);
                keys.Remove(cacheKey);
                _cache.Set(keyStoreFinalKey, keys);
            }
        }

        public async Task RemoveFromCacheAsync(string key, bool isFullKey = false)
        {
            await Task.Factory.StartNew(() => RemoveFromCache(key, isFullKey)).ConfigureAwait(false);
        }

        public void Set(string key, object value, TimeSpan? expiry = null, bool isFullKey = false)
        {
            if (key == null || value == null) return;

            var finalKey = GetFinalKey(key, isFullKey);

            var newKey = !CheckExisted(finalKey, true);

            if (expiry.HasValue)
            {
                _cache.Set(finalKey, value, expiry.Value);
            }
            else
            {
                _cache.Set(finalKey, value);
            }

            //由于MemoryCache不支持遍历Keys，所以需要单独储存
            if (newKey)
            {
                var keyStoreFinalKey = GetFinalKey(KEY_STORE_KEY);

                List<string> keys;
                if (!CheckExisted(keyStoreFinalKey, true))
                {
                    keys = new List<string>();
                }
                else
                {
                    keys = _cache.Get<List<string>>(keyStoreFinalKey);
                }
                keys.Add(finalKey);
                _cache.Set(keyStoreFinalKey, keys);
            }
        }

        public async Task SetAsync(string key, object value, TimeSpan? expiry = null, bool isFullKey = false)
        {
            await Task.Factory.StartNew(() => Set(key, value, expiry, isFullKey)).ConfigureAwait(false);
        }

        public void Update(string key, object value, TimeSpan? expiry = null, bool isFullKey = false)
        {
            Set(key, value, expiry, isFullKey);
        }

        public async Task UpdateAsync(string key, object value, TimeSpan? expiry = null, bool isFullKey = false)
        {
            await Task.Factory.StartNew(() => Update(key, value, expiry, isFullKey)).ConfigureAwait(false);
        }
    }
}
