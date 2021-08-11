using System;

using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Framework;
using Leelite.Modules.MessageCenter.Contexts;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.MessageCenter
{
    [DependsOn(typeof(FrameworkModule))]
    public class MessageCenterModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddDbContext<MessageContext>("Default", true);

            services.AddSingleton<IPushProviderFactory, PushProviderFactory>();
        }
    }
}
