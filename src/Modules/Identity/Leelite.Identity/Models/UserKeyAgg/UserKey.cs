using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Enabled;

namespace Leelite.Identity.Models.UserKeyAgg
{
    public class UserKey : AggregateRoot<long>, IEnabled
    {
        /// <summary>
        /// 钥匙Id
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 签名规则
        /// </summary>
        public string SignatureRule { get; set; }

        /// <summary>
        /// 签名数据
        /// </summary>
        public string SignatureData { get; set; }

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }
    }
}
