using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Message.Dtos.SessionDtos;
using Leelite.Modules.Message.Interfaces;
using Leelite.Modules.Message.Models.SessionAgg;
using Leelite.Modules.Message.Repositories;
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
