namespace Leelite.Framework.Models.Audit
{
    /// <summary>
    /// 软删除审计
    /// </summary>
    public interface ISoftDeletionAudited<TUserKey>
    {
        /// <summary>
        /// 删除人标识
        /// </summary>
        TUserKey DeleterId { get; set; }

        /// <summary>
        /// 删除人
        /// </summary>
        string Deleter { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? DeletionTime { get; set; }
    }
}
