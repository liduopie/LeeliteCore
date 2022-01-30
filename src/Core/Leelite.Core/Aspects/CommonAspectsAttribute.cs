using AspectInjector.Broker;

namespace Leelite.Core.Aspects
{
    [Injection(typeof(DebugLogAspect))]
    [Injection(typeof(ValidationAspect))]
    public class CommonAspectsAttribute : Attribute
    {
    }
}
