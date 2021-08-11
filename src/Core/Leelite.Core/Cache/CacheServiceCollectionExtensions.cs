using Leelite.Commons.Host;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;

using ZiggyCreatures.Caching.Fusion;

namespace Leelite.Core.Cache
{
    public static class CacheServiceCollectionExtensions
    {
        public static void AddCache(this IServiceCollection services)
        {
            var configuration = HostManager.Context.HostServices.GetService<IConfiguration>();

            services.AddMemoryCache();

            // REGISTER REDIS AS A DISTRIBUTED CACHE
            services.AddStackExchangeRedisCache(options =>
            {
                configuration.GetSection("Cache:RedisCacheOptions").Bind(options);
            });

            // REGISTER THE FUSION CACHE SERIALIZER
            services.AddFusionCacheSystemTextJsonSerializer();

            // REGISTER FUSION CACHE
            services.AddFusionCache(options =>
            {
                configuration.GetSection("Cache:FusionCacheEntryOptions").Bind(options);

                options.DefaultEntryOptions = new FusionCacheEntryOptions
                {
                    // CACHE DURATION
                    Duration = TimeSpan.FromMinutes(1),

                    // FAIL-SAFE OPTIONS
                    IsFailSafeEnabled = true,
                    FailSafeMaxDuration = TimeSpan.FromHours(2),
                    FailSafeThrottleDuration = TimeSpan.FromSeconds(30),

                    // FACTORY TIMEOUTS
                    FactorySoftTimeout = TimeSpan.FromMilliseconds(100),
                    FactoryHardTimeout = TimeSpan.FromMilliseconds(1500),

                    // DISTRIBUTED CACHE
                    DistributedCacheSoftTimeout = TimeSpan.FromSeconds(1),
                    DistributedCacheHardTimeout = TimeSpan.FromSeconds(2),
                    AllowBackgroundDistributedCacheOperations = true,

                    // JITTERING
                    JitterMaxDuration = TimeSpan.FromSeconds(2)
                };

                // DISTIBUTED CACHE CIRCUIT-BREAKER
                options.DistributedCacheCircuitBreakerDuration = TimeSpan.FromSeconds(2);

                // CUSTOM LOG LEVELS
                options.FailSafeActivationLogLevel = LogLevel.Debug;
                options.SerializationErrorsLogLevel = LogLevel.Warning;
                options.DistributedCacheSyntheticTimeoutsLogLevel = LogLevel.Debug;
                options.DistributedCacheErrorsLogLevel = LogLevel.Error;
                options.FactorySyntheticTimeoutsLogLevel = LogLevel.Debug;
                options.FactoryErrorsLogLevel = LogLevel.Error;
            });
        }
    }
}
