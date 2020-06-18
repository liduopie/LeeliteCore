using Leelite.Framework.Service.Dtos;
using Leelite.Modules.Identity.Models.UserTokenAgg;

namespace Leelite.Modules.Identity.Dtos.UserTokenDtos
{
    public class UserTokenDto : IDto<UserTokenKey>
    {
        public UserTokenKey Id { get; set; }

        public string Value { get; set; }

    }
}
