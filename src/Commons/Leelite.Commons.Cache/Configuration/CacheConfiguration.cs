using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Leelite.Commons.Cache.Configuration
{
    internal class CacheConfiguration : ICacheConfiguration
    {
        private readonly List<ICacheConfigurator> _configurators;

        public IReadOnlyList<ICacheConfigurator> Configurators
        {
            get { return _configurators.ToImmutableList(); }
        }

        public CacheConfiguration()
        {
            _configurators = new List<ICacheConfigurator>();
        }

        public void Configure(string cacheName, Action<ICacheOptions> initAction)
        {
            _configurators.Add(new CacheConfigurator(cacheName, initAction));
        }
    }
}
