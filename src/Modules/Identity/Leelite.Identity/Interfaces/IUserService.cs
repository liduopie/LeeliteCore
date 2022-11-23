using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserDtos;
using Leelite.Identity.Models.UserAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IUserService : ICrudService<User, long, UserDto, UserCreateRequest, UserUpdateRequest, UserQueryParameter>
    {
    }
}
