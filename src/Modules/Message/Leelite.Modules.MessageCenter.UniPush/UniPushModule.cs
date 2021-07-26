using Leelite.Commons.Host;
using Leelite.Core.Module;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter.UniPush
{
    public class UniPushModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddSingleton<IUserClientIdService, UserClientIdService>();
            services.AddSingleton<IPushProvider, UniPushProvider>();
        }
    }
}
