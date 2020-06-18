using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.RoleClaimDtos;
using Leelite.Modules.Identity.Models.RoleClaimAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IRoleClaimService : ICrudService<RoleClaim, int, RoleClaimDto, RoleClaimCreateRequest, RoleClaimUpdateRequest, RoleClaimQueryParameter>
    {
    }
}
