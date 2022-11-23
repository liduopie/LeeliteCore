using Leelite.Framework.Service;
using Leelite.Identity.Dtos.RoleDtos;
using Leelite.Identity.Models.RoleAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IRoleService : ICrudService<Role, int, RoleDto, RoleCreateRequest, RoleUpdateRequest, RoleQueryParameter>
    {
    }
}
