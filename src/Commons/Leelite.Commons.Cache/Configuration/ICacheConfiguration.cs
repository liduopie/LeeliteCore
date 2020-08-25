using System;
using System.Collections.Generic;

namespace Leelite.Commons.Cache.Configuration
{
    /// <summary>
    /// Used to configure caching system.
    /// </summary>
    public interface ICacheConfiguration
    {
        /// <summary>
        /// List of all registered configurators.
        /// </summary>
        IReadOnlyList<ICacheConfigurator> Configurators { get; }

        /// <summary>
        /// Used to configure a specific cache. 
        /// </summary>
        /// <param name="cacheName">Cache name</param>
        /// <param name="initAction">
        /// An action to configure the cache.
        /// This action is called just after the cache is created.
        /// </param>
        void Configure(string cacheName, Action<ICacheOptions> initAction);
    }
}
