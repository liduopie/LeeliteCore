using Leelite.Commons.Host;
using Leelite.Core.Module;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.HealthChecks
{
    public class HealthChecksModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddHealthChecks()
                .AddDiskStorageHealthCheck(c => { }, tags: new[] { "process" })
                .AddPrivateMemoryHealthCheck(maximumMemoryBytes: 1024 * 1024 * 1024, tags: new[] { "process" })
                .AddProcessAllocatedMemoryHealthCheck(maximumMegabytesAllocated: 100, tags: new[] { "process" })
                .AddWorkingSetHealthCheck(maximumMemoryBytes: 1024 * 1024 * 1024, tags: new[] { "process" });
        }
    }
}
