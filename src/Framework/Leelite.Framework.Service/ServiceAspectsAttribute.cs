using System;

using AspectInjector.Broker;

using Leelite.Core.Aspects;
using Leelite.Framework.Service.Aspects;

namespace Leelite.Framework.Service
{
    [Injection(typeof(DebugLogAspect))]
    [Injection(typeof(ServiceLogAspect))]
    [Injection(typeof(ValidationAspect))]
    [Injection(typeof(UnitOfWorkAspect))]
    public class ServiceAspectsAttribute : Attribute
    {
    }
}
