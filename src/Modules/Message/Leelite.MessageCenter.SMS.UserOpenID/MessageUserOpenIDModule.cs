using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Modules.MessageCenter.Weixin;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter.UserOpenID
{
    public class MessageUserOpenIDModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddSingleton<IUserOpenIDFactory, DefaultUserOpenIDFactory>();
        }
    }
}
