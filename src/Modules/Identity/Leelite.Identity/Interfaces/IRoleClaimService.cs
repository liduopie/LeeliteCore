using Leelite.Framework.Service;
using Leelite.Identity.Dtos.RoleClaimDtos;
using Leelite.Identity.Models.RoleClaimAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IRoleClaimService : ICrudService<RoleClaim, int, RoleClaimDto, RoleClaimCreateRequest, RoleClaimUpdateRequest, RoleClaimQueryParameter>
    {
    }
}
