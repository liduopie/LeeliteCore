using Leelite.Framework.Service.Dtos;
using Leelite.Modules.Identity.Models.UserRoleAgg;

namespace Leelite.Modules.Identity.Dtos.UserRoleDtos
{
    public class UserRoleUpdateRequest : IUpdateRequest<UserRoleKey>
    {
        public UserRoleKey Id { get; set; }

    }
}
