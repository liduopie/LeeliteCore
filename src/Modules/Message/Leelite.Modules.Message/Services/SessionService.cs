using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Message.Models.SessionAgg.Dtos.SessionDtos;
using Leelite.Modules.Message.Models.SessionAgg.Interfaces;
using Leelite.Modules.Message.Models.SessionAgg.Models.SessionAgg;
using Leelite.Modules.Message.Models.SessionAgg.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Message.Models.SessionAgg.Services
{
    public class SessionService : CrudService<Session, long, SessionDto, SessionCreateRequest, SessionUpdateRequest, SessionQueryParameter>, ISessionService
    {
        public SessionService(
            ISessionRepository repository,
            ICommandBus commandBus,
            ILogger<SessionService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
