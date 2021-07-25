using Leelite.Commons.Host;
using Leelite.Core.Module;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter.Weixin
{
    public class WeixinMPModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddSingleton<IUserOpenIDService, UserOpenIDService>();
            services.AddSingleton<IPushProvider, WeixinMPPushProvider>();
            services.AddSingleton<IPushProvider, WeixinWxOpenPushProvider>();
        }
    }
}
