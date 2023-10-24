using Leelite.Core.Module;
using Leelite.MessageCenter.SMS;
using Leelite.MessageCenter.UserPhone;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter.UserPhone
{
    public class MessageUserPhoneModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserPhoneFactory, DefaultUserPhoneFactory>();
        }
    }
}
