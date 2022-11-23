using Leelite.Framework.Service.Dtos;
using Leelite.Identity.Models.UserLoginAgg;

namespace Leelite.Identity.Dtos.UserLoginDtos
{
    public class UserLoginUpdateRequest : IUpdateRequest<UserLoginKey>
    {
        public UserLoginKey Id { get; set; }

        public string ProviderDisplayName { get; set; }

        public long UserId { get; set; }

    }
}
