using AspectInjector.Broker;

using Microsoft.Extensions.Logging;

using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Leelite.Core.Aspects
{
    [Aspect(Scope.Global)]
    public class DebugLogAspect
    {
        private readonly ILoggerFactory _loggerFactory;

        public DebugLogAspect()
        {
            _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
        }

        [Advice(Kind.After, Targets = Target.Public | Target.Method)]
        public void After(
            [Argument(Source.Type)] Type type,
            [Argument(Source.ReturnValue)] object value,
            [Argument(Source.ReturnType)] Type valueType)
        {
            var logger = _loggerFactory.CreateLogger(type.GetGenericTypeName());

            logger.LogDebug($"Executing resultType {valueType.Name}");
            logger.LogDebug($"Executing result {JsonSerializer.Serialize(value, new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve })}");
        }

        [Advice(Kind.Around, Targets = Target.Public | Target.Method)]
        public object Around(
            [Argument(Source.Type)] Type type,
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] args,
            [Argument(Source.Target)] Func<object[], object> method)
        {

            var logger = _loggerFactory.CreateLogger(type.GetGenericTypeName());

            logger.LogDebug($"Executing method {name}");

            foreach (var arg in args)
            {
                if (arg.GetType() == typeof(CancellationToken)) continue;

                logger.LogDebug($"Executing args {JsonSerializer.Serialize(arg, new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve })}");
            }

            var sw = Stopwatch.StartNew();

            var result = method(args);

            sw.Stop();

            logger.LogDebug($"Executed method {name} in {sw.ElapsedMilliseconds} ms");

            return result;
        }


    }
}
