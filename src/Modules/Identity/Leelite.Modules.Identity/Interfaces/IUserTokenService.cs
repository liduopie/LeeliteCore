using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserTokenDtos;
using Leelite.Modules.Identity.Models.UserTokenAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IUserTokenService : ICrudService<UserToken, UserTokenKey, UserTokenDto, UserTokenCreateRequest, UserTokenUpdateRequest, UserTokenQueryParameter>
    {
    }
}
