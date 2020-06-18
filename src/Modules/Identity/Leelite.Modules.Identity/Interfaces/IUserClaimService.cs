using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserClaimDtos;
using Leelite.Modules.Identity.Models.UserClaimAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IUserClaimService : ICrudService<UserClaim, long, UserClaimDto, UserClaimCreateRequest, UserClaimUpdateRequest, UserClaimQueryParameter>
    {
    }
}
