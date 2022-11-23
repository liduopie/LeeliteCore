using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimCreateRequest : IRequest
    {
        public int RoleId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

    }
}
