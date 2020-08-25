using System;
using System.Collections.Generic;

using Leelite.Commons.Cache.BaseCache;

namespace Leelite.Commons.Cache
{
    public interface ICacheManager<TCache> : IDisposable where TCache : class
    {
        /// <summary>
        /// Gets all caches.
        /// </summary>
        /// <returns>List of caches</returns>
        IReadOnlyList<TCache> GetAllCaches();

        /// <summary>
        /// Gets a <see cref="ICache"/> instance.
        /// It may create the cache if it does not already exists.
        /// </summary>
        /// <param name="name">
        /// Unique and case sensitive name of the cache.
        /// </param>
        /// <returns>The cache reference</returns>
        TCache GetCache(string name);
    }
}
