using Leelite.AspNetCore.Modular;
using Leelite.Core.Module.Dependency;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.MessageCenter.SignalR
{
    [DependsOn(typeof(MessageCenterModule))]
    public class MessageCenterSignalRModule : MvcModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPushProvider, SignalRPushProvider>();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MessageCenterHub>("message-center");
            });
        }
    }
}
