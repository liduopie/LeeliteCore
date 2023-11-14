namespace Leelite.Framework.Models.DataAccessSet
{
    /// <summary>
    /// 数据权限
    /// </summary>
    public interface IDataAccessSet<TKey>
    {
        /// <summary>
        /// 所有者
        /// </summary>
        string OwnerId { get; set; }

        /// <summary>
        /// 权限集合
        /// </summary>
        IList<IAccessItem<TKey>> Accesses { get; set; }
    }
}
