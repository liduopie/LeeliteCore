using Leelite.Core.Module;
using Leelite.MessageCenter.UserOpenID;
using Leelite.MessageCenter.Weixin;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.MessageCenter.UserOpenID
{
    public class MessageUserOpenIDModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserOpenIDFactory, DefaultUserOpenIDFactory>();
        }
    }
}
