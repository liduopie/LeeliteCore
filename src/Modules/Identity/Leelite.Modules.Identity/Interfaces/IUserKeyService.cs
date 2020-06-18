using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserKeyDtos;
using Leelite.Modules.Identity.Models.UserKeyAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IUserKeyService : ICrudService<UserKey, long, UserKeyDto, UserKeyCreateRequest, UserKeyUpdateRequest, UserKeyQueryParameter>
    {
    }
}
