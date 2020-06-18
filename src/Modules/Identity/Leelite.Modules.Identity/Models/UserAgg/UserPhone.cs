using Microsoft.AspNetCore.Identity;

namespace Leelite.Modules.Identity.Models.UserAgg
{
    /// <summary>
    /// 账号手机号
    /// </summary>
    public class UserPhone
    {
        /// <summary>
        /// Gets or sets a telephone number for the user.
        /// </summary>
        [ProtectedPersonalData]
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their telephone address.
        /// </summary>
        /// <value>True if the telephone number has been confirmed, otherwise false.</value>
        [PersonalData]
        public virtual bool PhoneNumberConfirmed { get; set; }
    }
}
