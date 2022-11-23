using Leelite.Framework.Service.Dtos;
using Leelite.Identity.Models.UserTokenAgg;

namespace Leelite.Identity.Dtos.UserTokenDtos
{
    public class UserTokenUpdateRequest : IUpdateRequest<UserTokenKey>
    {
        public UserTokenKey Id { get; set; }

        public string Value { get; set; }

    }
}
