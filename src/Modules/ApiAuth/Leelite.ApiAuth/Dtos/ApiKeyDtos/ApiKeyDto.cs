using System.Security.Claims;

using Leelite.Framework.Service.Dtos;

namespace Leelite.ApiAuth.Dtos.ApiKeyDtos
{
    public class ApiKeyDto : IDto<long>
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Key { get; set; }

        public string OwnerName { get; set; }

        public ICollection<Claim> Claims { get; set; }

    }
}
