using AspectInjector.Broker;

namespace Leelite.Core.Cache
{
    //[Injection(typeof(CacheAspect))]
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute(string key) : Attribute
    {
        public string Key { get; } = key;
    }
}
