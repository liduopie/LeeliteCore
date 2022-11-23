using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Modules.MessageCenter.SMS;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter.UserPhone
{
    public class MessageUserPhoneModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddSingleton<IUserPhoneFactory, DefaultUserPhoneFactory>();
        }
    }
}
