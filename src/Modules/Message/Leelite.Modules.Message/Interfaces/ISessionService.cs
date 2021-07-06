using Leelite.Framework.Service;
using Leelite.Modules.Message.Models.SessionAgg.Dtos.SessionDtos;
using Leelite.Modules.Message.Models.SessionAgg.Models.SessionAgg;

namespace Leelite.Modules.Message.Models.SessionAgg.Interfaces
{
    public interface ISessionService : ICrudService<Session, long, SessionDto, SessionCreateRequest, SessionUpdateRequest, SessionQueryParameter>
    {
    }
}
