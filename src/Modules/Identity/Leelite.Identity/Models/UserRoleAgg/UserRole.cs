using System;
using System.Collections.Generic;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Model;

namespace Leelite.Identity.Models.UserRoleAgg
{
    /// <summary>
    /// Represents the link between a user and a role.
    /// </summary>
    public class UserRole : AggregateRoot<UserRoleKey>
    {
        private long _userId;
        private int _roleId;

        public override UserRoleKey Id
        {
            get
            {
                return new UserRoleKey()
                {
                    UserId = _userId,
                    RoleId = _roleId
                };
            }
            set
            {
                _userId = value.UserId;
                _roleId = value.RoleId;
            }
        }
    }

    public class UserRoleKey : ValueObject<UserRoleKey>
    {
        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the role that is linked to the user.
        /// </summary>
        public int RoleId { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { UserId, RoleId };
        }
    }
}
