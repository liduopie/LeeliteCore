using Microsoft.AspNetCore.Identity;

namespace Leelite.Modules.Identity.Models.UserAgg
{
    /// <summary>
    /// 账号名称
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// Gets or sets the user name for this user.
        /// </summary>
        [ProtectedPersonalData]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the normalized user name for this user.
        /// </summary>
        public string NormalizedUserName { get; set; }
    }
}
