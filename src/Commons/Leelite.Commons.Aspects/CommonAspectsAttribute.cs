using System;
using AspectInjector.Broker;

namespace Leelite.Commons.Aspects
{
    [Injection(typeof(DebugLogAspect))]
    [Injection(typeof(ValidationAspect))]
    public class CommonAspectsAttribute : Attribute
    {
    }
}
