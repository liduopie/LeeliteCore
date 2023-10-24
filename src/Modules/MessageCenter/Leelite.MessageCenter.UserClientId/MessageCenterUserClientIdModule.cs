using Leelite.Core.Module;
using Leelite.MessageCenter.UniPush;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.MessageCenter.UserClientId
{
    public class MessageCenterUserClientIdModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserClientIdFactory, DefaultUserClientIdFactory>();
        }
    }
}
