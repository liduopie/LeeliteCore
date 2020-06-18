using System;

namespace Leelite.Framework.Models.Audit
{
    /// <summary>
    /// 更新操作审计
    /// </summary>
    public interface IModificationAudited<TKey>
    {
         /// <summary>
        /// 最后修改人标识
        /// </summary>
        TKey LastModifierId { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        string Modifier { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}