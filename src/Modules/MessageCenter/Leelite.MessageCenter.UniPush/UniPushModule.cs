using Leelite.Core.Module;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.MessageCenter.UniPush
{
    public class UniPushModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserClientIdService, UserClientIdService>();
            services.AddSingleton<IPushProvider, UniPushProvider>();
        }
    }
}
