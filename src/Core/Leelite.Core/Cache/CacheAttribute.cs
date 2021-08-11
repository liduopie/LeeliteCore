using AspectInjector.Broker;

using System;

namespace Leelite.Core.Cache
{

    [Injection(typeof(CacheAspect))]
    public class CacheAttribute : Attribute
    {
        public CacheAttribute(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }
}
