using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserDtos;
using Leelite.Modules.Identity.Models.UserAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IUserService : ICrudService<User, long, UserDto, UserCreateRequest, UserUpdateRequest, UserQueryParameter>
    {
    }
}
