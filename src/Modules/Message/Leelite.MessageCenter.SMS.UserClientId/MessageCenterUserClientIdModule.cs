using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Modules.MessageCenter.UniPush;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter.UserClientId
{
    public class MessageCenterUserClientIdModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddSingleton<IUserClientIdFactory, DefaultUserClientIdFactory>();
        }
    }
}
