namespace Leelite.Framework.Models.Audit
{
    /// <summary>
    /// 创建操作审计
    /// </summary>
    public interface ICreationAudited<TUserKey>
    {
        /// <summary>
        /// 创建人标识
        /// </summary>
        TUserKey CreatorId { get; set; }

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