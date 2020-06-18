using System.Collections.Generic;
using Leelite.Modules.Identity.Models.RoleAgg;
using Leelite.Modules.Identity.Models.UserAgg;

namespace Leelite.Modules.Identity.Configuration
{
    public class IdentityDataConfiguration
    {
        public List<Role> Roles { get; set; }
        public List<User> Users { get; set; }
    }
}
