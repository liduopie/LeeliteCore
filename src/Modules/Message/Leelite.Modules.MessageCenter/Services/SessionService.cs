using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.SessionDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.SessionAgg;
using Leelite.Modules.MessageCenter.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.MessageCenter.Models.SessionAgg.Services
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
