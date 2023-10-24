using Leelite.Commons.Host;
using Leelite.Core.Module;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.MessageCenter.Weixin
{
    public class WeixinMPModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserOpenIDService, UserOpenIDService>();
            services.AddSingleton<IPushProvider, WeixinMPPushProvider>();
            services.AddSingleton<IPushProvider, WeixinWxOpenPushProvider>();
        }
    }
}
