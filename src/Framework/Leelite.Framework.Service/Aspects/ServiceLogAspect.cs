using System;
using AspectInjector.Broker;
using Leelite.Commons.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leelite.Framework.Service.Aspects
{
    [Aspect(Scope.Global)]
    public class ServiceLogAspect
    {
        private ILoggerFactory _loggerFactory;

        public ServiceLogAspect()
        {
            _loggerFactory = HostManager.WebApplication.Services.GetService<ILoggerFactory>();
        }

        [Advice(Kind.Before, Targets = Target.Public | Target.Method)]
        public void Before(
            [Argument(Source.Type)] Type type,
            [Argument(Source.Name)] string name)
        {
            var logger = _loggerFactory.CreateLogger(type.GetGenericTypeName());

            logger.LogInformation($"Service method {name}");
        }
    }
}
