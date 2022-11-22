using Leelite.Commons.Host;
using Leelite.Core.Module;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.HealthChecks
{
    public class HealthChecksModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDiskStorageHealthCheck(c => { }, tags: new[] { "process" })
                .AddPrivateMemoryHealthCheck(maximumMemoryBytes: 1024 * 1024 * 1024, tags: new[] { "process" })
                .AddProcessAllocatedMemoryHealthCheck(maximumMegabytesAllocated: 100, tags: new[] { "process" })
                .AddWorkingSetHealthCheck(maximumMemoryBytes: 1024 * 1024 * 1024, tags: new[] { "process" });
        }
    }
}
