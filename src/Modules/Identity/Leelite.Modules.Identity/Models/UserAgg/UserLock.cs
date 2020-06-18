using System;

namespace Leelite.Modules.Identity.Models.UserAgg
{
    /// <summary>
    /// 账号锁定
    /// </summary>
    public class UserLock
    {
        /// <summary>
        /// Gets or sets the date and time, in UTC, when any user lockout ends.
        /// </summary>
        /// <remarks>
        /// A value in the past means the user is not locked out.
        /// </remarks>
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the user could be locked out.
        /// </summary>
        /// <value>True if the user could be locked out, otherwise false.</value>
        public bool LockoutEnabled { get; set; }
    }
}
