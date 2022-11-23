using Leelite.AspNetCore.Modular;
using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace Leelite.Modules.MessageCenter.SignalR
{
    [DependsOn(typeof(MessageCenterModule))]
    public class MessageCenterSignalRModule : MvcModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddSingleton<IPushProvider, SignalRPushProvider>();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MessageCenterHub>("/message-center");
            });
        }
    }
}
