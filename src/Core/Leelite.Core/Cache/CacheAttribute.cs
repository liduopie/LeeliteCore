using AspectInjector.Broker;

using System;

namespace Leelite.Core.Cache
{

    [Injection(typeof(CacheAspect))]
    public class CacheAttribute : Attribute
    {
        public CacheAttribute(Type keyType)
        {
            KeyType = keyType;
            Key = keyType.Name;
        }

        public Type KeyType { get; }

        public string Key { get; }

        /// <summary>
        /// 单位秒
        /// </summary>
        public int Duration { get; set; }
    }
}
