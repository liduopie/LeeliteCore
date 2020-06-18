using Leelite.Framework.Service.Dtos;
using Leelite.Modules.Identity.Models.UserLoginAgg;

namespace Leelite.Modules.Identity.Dtos.UserLoginDtos
{
    public class UserLoginUpdateRequest : IUpdateRequest<UserLoginKey>
    {
        public UserLoginKey Id { get; set; }

        public string ProviderDisplayName { get; set; }

        public long UserId { get; set; }

    }
}
