using System.Collections.Generic;

namespace Leelite.Framework.Data.Query.OrderBy
{

    /// <summary>
    /// 排序接口
    /// </summary>
    public interface IOrderBy
    {
        /// <summary>
        /// 排序条件
        /// </summary>
        IList<SortParam> SortItems { get; set; }
    }
}
