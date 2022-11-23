using System;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Identity.Models.RoleAgg
{
    public class Role : AggregateRoot<int>
    {
        /// <summary>
        /// Gets or sets the name for this role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the normalized name for this role.
        /// </summary>
        public string NormalizedName { get; set; }

        /// <summary>
        /// A random value that should change whenever a role is persisted to the store
        /// </summary>
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Returns the name of the role.
        /// </summary>
        /// <returns>The name of the role.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
