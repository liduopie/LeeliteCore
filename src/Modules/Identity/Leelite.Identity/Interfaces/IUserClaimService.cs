using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserClaimDtos;
using Leelite.Identity.Models.UserClaimAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IUserClaimService : ICrudService<UserClaim, long, UserClaimDto, UserClaimCreateRequest, UserClaimUpdateRequest, UserClaimQueryParameter>
    {
    }
}
