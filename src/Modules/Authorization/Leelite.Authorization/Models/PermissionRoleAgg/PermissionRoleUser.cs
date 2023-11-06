using System.Collections.Generic;
using Leelite.Framework.Domain.Model;

namespace Leelite.Authorization.Models.PermissionRoleAgg
{
    public class PermissionRoleUser : ValueObject<PermissionRoleUser>
    {
        public long PermissionRoleId { get; set; }
        public long UserId { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { PermissionRoleId, UserId };
        }
    }
}
