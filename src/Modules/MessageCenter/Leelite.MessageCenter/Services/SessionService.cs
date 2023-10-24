using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.SessionDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.SessionAgg;
using Leelite.MessageCenter.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.MessageCenter.Services
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
