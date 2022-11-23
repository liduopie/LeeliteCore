namespace Leelite.Identity.Models.UserAgg
{
    /// <summary>
    /// 账号密码
    /// </summary>
    public class UserPassword
    {
        /// <summary>
        /// Gets or sets a salted and hashed representation of the password for this user.
        /// </summary>
        public string PasswordHash { get; set; }
    }
}
