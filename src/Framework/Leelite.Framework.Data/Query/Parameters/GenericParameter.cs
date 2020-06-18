using System.Collections.Generic;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;

namespace Leelite.Framework.Data.Query.Parameters
{
    /// <summary>
    /// 一般条件查询参数
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class GenericParameter<T> : Criterion<T>, IQueryParameter<T>, IOrderBy
    {
        /// <inheritdoc/>
        public IList<SortParam> SortItems { get; set; }

        public GenericParameter()
        {
            SortItems = new List<SortParam>();
        }
    }
}
