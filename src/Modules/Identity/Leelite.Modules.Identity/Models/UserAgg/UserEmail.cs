using Microsoft.AspNetCore.Identity;

namespace Leelite.Modules.Identity.Models.UserAgg
{
    /// <summary>
    /// 账号邮箱
    /// </summary>
    public class UserEmail
    {
        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        [ProtectedPersonalData]
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the normalized email address for this user.
        /// </summary>
        public virtual string NormalizedEmail { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their email address.
        /// </summary>
        /// <value>True if the email address has been confirmed, otherwise false.</value>
        [PersonalData]
        public virtual bool EmailConfirmed { get; set; }
    }
}
