using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Model;

namespace Leelite.Identity.Models.UserRoleAgg
{
    /// <summary>
    /// Represents the link between a user and a role.
    /// </summary>
    public class UserRole : AggregateRoot<UserRoleKey>
    {
        public override UserRoleKey Id { get; set; }

        public long UserId
        {
            get
            {
                return Id.UserId;
            }
            set
            {
                Id.UserId = value;
            }
        }

        public int RoleId
        {
            get
            {
                return Id.RoleId;
            }
            set
            {
                Id.RoleId = value;
            }
        }
    }

    [ComplexType]
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
