namespace Leelite.Framework.Models.DataAccessSet
{
    /// <summary>
    /// 数据权限项
    /// </summary>
    public interface IAccessItem<TKey>
    {
        /// <summary>
        /// 标识
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// 数据Id
        /// </summary>
        TKey DataId { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        string Permission { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        string UserId { get; set; }

        /// <summary>
        /// 分组Id
        /// </summary>
        string GroupId { get; set; }
    }
}
