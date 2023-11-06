using System;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Authorization.Models.UserPermissionValueAgg
{
    public class RolePermissionValue : AggregateRoot<RolePermissionValueKey>
    {
    }

    public class RolePermissionValueKey : IEquatable<RolePermissionValueKey>
    {
        public long PermissionRoleId { get; set; }
        public string PermissionCode { get; set; }

        public bool Equals(RolePermissionValueKey other)
        {
            return PermissionRoleId == other.PermissionRoleId &&
                PermissionCode == other.PermissionCode;
        }
    }
}
