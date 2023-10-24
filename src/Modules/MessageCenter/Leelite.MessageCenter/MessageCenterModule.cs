using Leelite.Core.Module;
using Leelite.Framework.Service.Commands;
using Leelite.MessageCenter.CommandHandlers;
using Leelite.MessageCenter.Contexts;
using Leelite.MessageCenter.Dtos.SessionDtos;
using Leelite.MessageCenter.Models.SessionAgg;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.MessageCenter
{
    public class MessageCenterModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MessageContext>("Default", true);

            services.AddSingleton<IPushProviderFactory, PushProviderFactory>();

            services.AddTransient<IRequestHandler<CreateCommand<SessionCreateRequest, SessionDto, Session, long>, SessionDto>, SessionCreateCommandHandler>();

            services.AddSingleton<IPushProvider, AppMessagePushProvider>();
            services.AddSingleton<IPushProvider, SmallAppMessagePushProvider>();
            services.AddSingleton<IPushProvider, WebMessagePushProvider>();
        }
    }
}
