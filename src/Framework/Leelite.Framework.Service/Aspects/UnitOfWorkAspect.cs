using System;
using System.Reflection;
using AspectInjector.Broker;
using Leelite.Commons.Host;
using Leelite.Framework.Domain.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leelite.Framework.Service.Aspects
{
    /// <summary>
    /// 工作单元拦截器
    /// </summary>
    [Aspect(Scope.Global)]
    public class UnitOfWorkAspect
    {
        private ILoggerFactory _loggerFactory;

        public UnitOfWorkAspect()
        {
            _loggerFactory = HostManager.WebApplication.Services.GetService<ILoggerFactory>();
        }

        [Advice(Kind.Around, Targets = Target.Public | Target.Method)]
        public object HandleMethod(
                [Argument(Source.Type)] Type type,
                [Argument(Source.Name)] string name,
                [Argument(Source.Arguments)] object[] arguments,
                [Argument(Source.Metadata)]MethodBase metadata,
                [Argument(Source.Target)] Func<object[], object> method,
                [Argument(Source.Triggers)] Attribute[] triggers)
        {
            var uowAttr = metadata.GetCustomAttribute<UnitOfWorkAttribute>();

            IUnitOfWork unitOfWork = null;

            var logger = _loggerFactory.CreateLogger(type.GetGenericTypeName());

            if (uowAttr != null)
            {
                unitOfWork = (IUnitOfWork)HostManager.WebApplication.Services.GetService(typeof(IUnitOfWork));

                // 启动工作单元
                unitOfWork.Begin();


                logger.LogInformation($"UnitOfWork Begin {name}");
            }

            var result = method(arguments);

            if (unitOfWork != null)
            {
                // 提交工作单元
                unitOfWork.Commit();

                logger.LogInformation($"UnitOfWork Commit {name}");
            }

            return result;
        }
    }
}
