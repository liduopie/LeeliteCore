using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserLoginDtos;
using Leelite.Modules.Identity.Models.UserLoginAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IUserLoginService : ICrudService<UserLogin, UserLoginKey, UserLoginDto, UserLoginCreateRequest, UserLoginUpdateRequest, UserLoginQueryParameter>
    {
    }
}
