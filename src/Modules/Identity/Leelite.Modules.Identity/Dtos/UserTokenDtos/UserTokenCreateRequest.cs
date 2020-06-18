using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.Identity.Dtos.UserTokenDtos
{
    public class UserTokenCreateRequest : IRequest
    {
        public string Value { get; set; }

    }
}
