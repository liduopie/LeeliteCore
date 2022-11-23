using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.UserTokenDtos
{
    public class UserTokenCreateRequest : IRequest
    {
        public string Value { get; set; }

    }
}
