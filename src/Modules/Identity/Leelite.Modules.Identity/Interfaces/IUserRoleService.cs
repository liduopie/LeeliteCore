using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserRoleDtos;
using Leelite.Modules.Identity.Models.UserRoleAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IUserRoleService : ICrudService<UserRole, UserRoleKey, UserRoleDto, UserRoleCreateRequest, UserRoleUpdateRequest, UserRoleQueryParameter>
    {
    }
}
