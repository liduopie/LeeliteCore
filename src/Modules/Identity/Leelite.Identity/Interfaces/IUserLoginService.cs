using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserLoginDtos;
using Leelite.Identity.Models.UserLoginAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IUserLoginService : ICrudService<UserLogin, UserLoginKey, UserLoginDto, UserLoginCreateRequest, UserLoginUpdateRequest, UserLoginQueryParameter>
    {
    }
}
