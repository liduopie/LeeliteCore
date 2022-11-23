using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimDto : IDto<int>
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

    }
}
