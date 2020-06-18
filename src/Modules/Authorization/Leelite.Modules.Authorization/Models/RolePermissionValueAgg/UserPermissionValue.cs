using System;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.Authorization.Models.RolePermissionValueAgg
{
    public class UserPermissionValue : AggregateRoot<UserPermissionValueKey>
    {
        public bool Value { get; set; }
    }

    public class UserPermissionValueKey : IEquatable<UserPermissionValueKey>
    {
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public string PermissionCode { get; set; }

        public bool Equals(UserPermissionValueKey other)
        {
            return OrganizationId == other.OrganizationId &&
                 UserId == other.UserId &&
                 PermissionCode == other.PermissionCode;
        }
    }
}
