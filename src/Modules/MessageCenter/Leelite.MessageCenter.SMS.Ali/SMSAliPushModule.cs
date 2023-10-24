using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.MessageCenter.SMS.Ali
{
    [DependsOn(typeof(MessageCenterModule))]
    public class SMSAliPushModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPushProvider, SMSAliPushProvider>();
        }
    }
}
