using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.UserClaimDtos
{
    public class UserClaimCreateRequest : IRequest
    {
        public long UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

    }
}
