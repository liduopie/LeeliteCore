using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Enabled;

namespace Leelite.Identity.Models.UserFingerprintAgg
{
    /// <summary>
    /// 用户指纹信息
    /// </summary>
    public class UserFingerprint : AggregateRoot<long>, IEnabled
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 指纹名称
        /// </summary>
        public string FingerName { get; set; }

        /// <summary>
        /// 指纹信息
        /// </summary>
        public string Fingerprint { get; set; }

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }
    }
}
