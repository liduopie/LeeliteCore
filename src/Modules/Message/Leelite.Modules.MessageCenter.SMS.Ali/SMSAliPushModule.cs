using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter.SMS.Ali
{
    [DependsOn(typeof(MessageCenterModule))]
    public class SMSAliPushModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddSingleton<IPushProvider, SMSAliPushProvider>();
        }
    }
}
