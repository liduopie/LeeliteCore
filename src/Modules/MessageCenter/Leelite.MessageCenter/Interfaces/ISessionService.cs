using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.SessionDtos;
using Leelite.MessageCenter.Models.SessionAgg;

namespace Leelite.MessageCenter.Interfaces
{
    public interface ISessionService : ICrudService<Session, long, SessionDto, SessionCreateRequest, SessionUpdateRequest, SessionQueryParameter>
    {
    }
}
