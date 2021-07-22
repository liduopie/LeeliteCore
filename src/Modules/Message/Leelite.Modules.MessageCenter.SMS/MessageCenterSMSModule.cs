using Leelite.Commons.Host;
using Leelite.Core.Module;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter.SMS
{
    public class MessageCenterSMSModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddSingleton<IUserPhoneService, UserPhoneService>();
        }
    }
}
