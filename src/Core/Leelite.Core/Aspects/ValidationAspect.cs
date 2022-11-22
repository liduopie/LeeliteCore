using System;
using System.Reflection;

using AspectInjector.Broker;

using FluentValidation;
using FluentValidation.Results;

using Leelite.Commons.Host;
using Leelite.Core.Validation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leelite.Core.Aspects
{
    [Aspect(Scope.Global)]
    public class ValidationAspect
    {
        private readonly ILoggerFactory _loggerFactory;
        private IServiceProvider _services;

        public ValidationAspect()
        {
            _services = HostManager.WebApplication.Services;
            _loggerFactory = _services.GetService<ILoggerFactory>();
        }

        [Advice(Kind.Before, Targets = Target.Public | Target.Method)]
        public void Before(
            [Argument(Source.Type)] Type type,
            [Argument(Source.Metadata)] MethodBase metadata,
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] args)
        {
            Type validatorInterfaceType = typeof(IValidator<>);

            ParameterInfo[] parameters = metadata.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                var attr = parameter.GetCustomAttribute<ValidAttribute>();

                if (attr == null) continue;

                var validatorType = validatorInterfaceType.MakeGenericType(parameter.ParameterType);

                var validator = _services.GetService(validatorType);

                MethodInfo validateMethod = validatorType.GetMethod("Validate");

                if (validator == null) continue;

                var logger = _loggerFactory.CreateLogger(type.GetGenericTypeName());

                foreach (var arg in args)
                {
                    if (arg.GetType() == parameter.ParameterType)
                    {
                        var result = (ValidationResult)validateMethod.Invoke(validator, new object[] { arg });

                        if (!result.IsValid)
                        {
                            logger.LogWarning($"Validation invalid method {name} parameter {parameter.ParameterType}");

                            throw new ValidationException(result.Errors);
                        }

                        logger.LogInformation($"Validation valid method {name} parameter {parameter.ParameterType}");
                    }
                }
            }

        }
    }
}
