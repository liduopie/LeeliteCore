using System.Collections.Generic;

namespace Leelite.Framework.Models.DataAccessSet
{
    /// <summary>
    /// 数据权限
    /// </summary>
    public interface IDataAccessSet<TKey>
    {
        /// <summary>
        /// 权限集合
        /// </summary>
        IList<IAccessItem<TKey>> Accesses { get; set; }
    }
}
