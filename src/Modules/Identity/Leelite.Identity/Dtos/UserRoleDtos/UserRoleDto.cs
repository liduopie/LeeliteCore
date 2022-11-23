using Leelite.Framework.Service.Dtos;
using Leelite.Identity.Models.UserRoleAgg;

namespace Leelite.Identity.Dtos.UserRoleDtos
{
    public class UserRoleDto : IDto<UserRoleKey>
    {
        public UserRoleKey Id { get; set; }

    }
}
