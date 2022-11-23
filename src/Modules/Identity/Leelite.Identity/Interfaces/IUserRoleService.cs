using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserRoleDtos;
using Leelite.Identity.Models.UserRoleAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IUserRoleService : ICrudService<UserRole, UserRoleKey, UserRoleDto, UserRoleCreateRequest, UserRoleUpdateRequest, UserRoleQueryParameter>
    {
    }
}
