using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimUpdateRequest : IUpdateRequest<int>
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

    }
}
