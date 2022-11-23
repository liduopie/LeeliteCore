using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserKeyDtos;
using Leelite.Identity.Models.UserKeyAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IUserKeyService : ICrudService<UserKey, long, UserKeyDto, UserKeyCreateRequest, UserKeyUpdateRequest, UserKeyQueryParameter>
    {
    }
}
