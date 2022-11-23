using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.SessionDtos;
using Leelite.Modules.MessageCenter.Models.SessionAgg;

namespace Leelite.Modules.MessageCenter.Interfaces
{
    public interface ISessionService : ICrudService<Session, long, SessionDto, SessionCreateRequest, SessionUpdateRequest, SessionQueryParameter>
    {
    }
}
