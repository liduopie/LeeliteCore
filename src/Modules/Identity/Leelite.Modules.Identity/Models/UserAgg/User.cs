using System;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Audit;
using Leelite.Framework.Models.Enabled;
using Leelite.Framework.Models.SoftDelete;
using Microsoft.AspNetCore.Identity;

namespace Leelite.Modules.Identity.Models.UserAgg
{
    /// <summary>
    /// Represents a user in the identity system
    /// </summary>
    public class User : AggregateRoot<long>,
        IAudit<long>,
        IEnabled,
        ISoftDelete
    {
        /// <summary>
        /// Gets or sets the primary key for this user.
        /// </summary>
        [PersonalData]
        public override long Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [PersonalData]
        public string NickName { get; set; }

        /// <summary>
        /// 实名
        /// </summary>
        [PersonalData]
        public string RealName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [PersonalData]
        public string Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [PersonalData]
        public DateTimeOffset Birthday { get; set; }

        /// <summary>
        /// 实名认证
        /// </summary>
        public bool IsReal { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string ProfilePicture { get; set; }

        /// <summary>
        /// A random value that must change whenever a users credentials change (password changed, login removed)
        /// </summary>
        public string SecurityStamp { get; set; }

        /// <summary>
        /// A random value that must change whenever a user is persisted to the store
        /// </summary>
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets a flag indicating if two factor authentication is enabled for this user.
        /// </summary>
        /// <value>True if 2fa is enabled, otherwise false.</value>
        [PersonalData]
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the number of failed login attempts for the current user.
        /// </summary>
        public int AccessFailedCount { get; set; }

        /// <summary>
        /// 锁定状态
        /// </summary>
        public UserLock Lock { get; set; } = new UserLock();

        /// <summary>
        /// 用户名
        /// </summary>
        public UserAccount Account { get; set; } = new UserAccount();

        /// <summary>
        /// 密码
        /// </summary>
        public UserPassword Password { get; set; } = new UserPassword();

        /// <summary>
        /// 电话号码
        /// </summary>
        public UserPhone Phone { get; set; } = new UserPhone();

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public UserEmail Email { get; set; } = new UserEmail();

        /// <summary>
        /// 身份证信息
        /// </summary>
        public UserIDCard IDCard { get; set; } = new UserIDCard();

        /// <summary>
        /// 人脸信息
        /// </summary>
        public UserFacial Facial { get; set; } = new UserFacial();

        #region IAudit

        /// <inheritdoc/>
        public long CreatorId { get; set; }

        /// <inheritdoc/>
        public string Creator { get; set; }

        /// <inheritdoc/>
        public DateTime? CreationTime { get; set; }

        /// <inheritdoc/>
        public long LastModifierId { get; set; }

        /// <inheritdoc/>
        public string Modifier { get; set; }

        /// <inheritdoc/>
        public DateTime? LastModificationTime { get; set; }

        #endregion

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }

        /// <inheritdoc/>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Returns the username for this user.
        /// </summary>
        public override string ToString()
            => Account.UserName;
    }
}
