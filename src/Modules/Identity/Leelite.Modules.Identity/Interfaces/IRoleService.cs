using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.RoleDtos;
using Leelite.Modules.Identity.Models.RoleAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IRoleService : ICrudService<Role, int, RoleDto, RoleCreateRequest, RoleUpdateRequest, RoleQueryParameter>
    {
    }
}
