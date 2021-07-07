using Leelite.Framework.Service;
using Leelite.Modules.Message.Dtos.SessionDtos;
using Leelite.Modules.Message.Models.SessionAgg;

namespace Leelite.Modules.Message.Interfaces
{
    public interface ISessionService : ICrudService<Session, long, SessionDto, SessionCreateRequest, SessionUpdateRequest, SessionQueryParameter>
    {
    }
}
