using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserTokenDtos;
using Leelite.Identity.Models.UserTokenAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IUserTokenService : ICrudService<UserToken, UserTokenKey, UserTokenDto, UserTokenCreateRequest, UserTokenUpdateRequest, UserTokenQueryParameter>
    {
    }
}
