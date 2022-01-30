using AspectInjector.Broker;

using Leelite.Commons.Host;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

using ZiggyCreatures.Caching.Fusion;

namespace Leelite.Core.Cache
{
    /// <summary>
    /// 缓存拦截器
    /// </summary>
    //[Aspect(Scope.Global)]
    //public class CacheAspect
    //{
    //    private ILoggerFactory _loggerFactory;
    //    private IServiceProvider _serviceProvider;

    //    public CacheAspect()
    //    {
    //        _serviceProvider = HostManager.Context.HostServices;
    //        _loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
    //    }

    //    private static readonly MethodInfo _asyncHandler = typeof(CacheAspect).GetMethod(nameof(CacheAspect.WrapAsync), BindingFlags.NonPublic | BindingFlags.Static);
    //    private static readonly MethodInfo _syncHandler = typeof(CacheAspect).GetMethod(nameof(CacheAspect.WrapSync), BindingFlags.NonPublic | BindingFlags.Static);
    //    private static readonly Type _voidTaskResult = Type.GetType("System.Threading.Tasks.VoidTaskResult");

    //    [Advice(Kind.Around, Targets = Target.Public | Target.Method)]
    //    public object HandleMethod(
    //             [Argument(Source.Type)] Type type,
    //             [Argument(Source.Name)] string name,
    //             [Argument(Source.Arguments)] object[] arguments,
    //             [Argument(Source.Metadata)] MethodBase metadata,
    //             [Argument(Source.Target)] Func<object[], object> method,
    //             [Argument(Source.Triggers)] Attribute[] triggers,
    //             [Argument(Source.ReturnType)] System.Type retType)
    //    {
    //        var cache = _serviceProvider.GetService<IFusionCache>();

    //        var cacheAttr = metadata.GetCustomAttribute<CacheAttribute>();

    //        var argumentList = new List<string>();
    //        foreach (var item in arguments)
    //        {
    //            argumentList.Add(item.ToString());
    //        }

    //        var cacheKey = $"{cacheAttr.Key}:{string.Join('-', argumentList)}";


    //        if (typeof(Task).IsAssignableFrom(retType)) //check if method is async, you can also check by statemachine attribute
    //        {
    //            var syncResultType = retType.IsConstructedGenericType ? retType.GenericTypeArguments[0] : _voidTaskResult;
    //            var tgt = method;

    //            // TODO: 不知道用途
    //            //if (!retType.IsConstructedGenericType)
    //            //    tgt = new Func<object[], object>(a => ((Task)method(a)).ContinueWith(t => (object)null));

    //            var result = cache.GetOrSet(
    //                cacheKey,
    //                _ => _asyncHandler.MakeGenericMethod(syncResultType).Invoke(this, new object[] { tgt, arguments, name }));

    //            return result;
    //        }
    //        else
    //        {
    //            retType = retType == typeof(void) ? typeof(object) : retType;

    //            var result = cache.GetOrSet(
    //                cacheKey,
    //                _ => _syncHandler.MakeGenericMethod(retType).Invoke(this, new object[] { method, arguments, name }));

    //            return result;
    //        }
    //    }

    //    private static T WrapSync<T>(Func<object[], object> target, object[] args, string name)
    //    {
    //        try
    //        {
    //            var result = (T)target(args);
    //            // Console.WriteLine($"Sync method `{name}` completes successfuly.");
    //            return result;
    //        }
    //        catch (Exception)
    //        {
    //            // Console.WriteLine($"Sync method `{name}` throws {e.GetType()} exception.");
    //            return default;
    //        }
    //    }

    //    private static async Task<T> WrapAsync<T>(Func<object[], object> target, object[] args, string name)
    //    {
    //        try
    //        {
    //            var result = await ((Task<T>)target(args)).ConfigureAwait(false);
    //            // Console.WriteLine($"Async method `{name}` completes successfuly.");
    //            return result;
    //        }
    //        catch (Exception)
    //        {
    //            // Console.WriteLine($"Async method `{name}` throws {e.GetType()} exception.");
    //            return default;
    //        }
    //    }
    //}
}
