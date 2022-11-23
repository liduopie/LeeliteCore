using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.UserLoginDtos
{
    public class UserLoginCreateRequest : IRequest
    {
        public string ProviderDisplayName { get; set; }

        public long UserId { get; set; }

    }
}
