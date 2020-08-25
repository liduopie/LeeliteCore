using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using Leelite.Commons.Cache.Configuration;

namespace Leelite.Commons.Cache
{
    public abstract class AbstractCacheManager<TCache> : ICacheManager<TCache> where TCache : class, ICacheOptions
    {
        protected readonly ICacheConfiguration _configuration;
        protected readonly ConcurrentDictionary<string, TCache> _caches;

        public AbstractCacheManager(ICacheConfiguration configuration)
        {
            _configuration = configuration;
            _caches = new ConcurrentDictionary<string, TCache>();
        }

        public IReadOnlyList<TCache> GetAllCaches()
        {
            return _caches.Values.ToImmutableList();
        }

        public TCache GetCache(string name)
        {
            if (name == default) throw new ArgumentNullException(nameof(name));

            return _caches.GetOrAdd(name, (cacheName) =>
            {
                var cache = CreateCacheImplementation(cacheName);

                var configurators = _configuration.Configurators.Where(c => c.CacheName == null || c.CacheName == cacheName);

                foreach (var configurator in configurators)
                {
                    configurator.InitAction?.Invoke(cache);
                }

                return cache;
            });
        }

        protected abstract void DisposeCaches();
        public void Dispose()
        {
            DisposeCaches();
            _caches.Clear();
        }

        /// <summary>
        /// Used to create actual cache implementation.
        /// </summary>
        /// <param name="name">Name of the cache</param>
        /// <returns>Cache object</returns>
        protected abstract TCache CreateCacheImplementation(string name);
    }
}
