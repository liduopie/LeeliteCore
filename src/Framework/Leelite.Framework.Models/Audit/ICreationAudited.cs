using System;

namespace Leelite.Framework.Models.Audit
{
    /// <summary>
    /// 创建操作审计
    /// </summary>
    public interface ICreationAudited<TKey>
    {
         /// <summary>
        /// 创建人标识
        /// </summary>
        TKey CreatorId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CreationTime { get; set; }
    }
}