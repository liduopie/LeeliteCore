using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.Identity.Dtos.UserClaimDtos
{
    public class UserClaimUpdateRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

    }
}
