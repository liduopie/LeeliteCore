namespace Leelite.Framework.Models.Audit
{
    /// <summary>
    /// 更新操作审计
    /// </summary>
    public interface IModificationAudited<TUserKey>
    {
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        TUserKey LastModifierId { get; set; }

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