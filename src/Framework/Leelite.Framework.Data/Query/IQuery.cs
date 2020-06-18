using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;

namespace Leelite.Framework.Data.Query
{
    public interface IQuery<T>
    {
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="criterion">查询条件</param>
        IQuery<T> Where(Criterion<T> criterion);

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="predicate">查询条件</param>
        IQuery<T> Where(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 添加排序
        /// </summary>
        /// <param name="filedName">排序字段</param>
        /// <param name="desc">是否降序</param>
        IQuery<T> OrderBy(string filedName, bool desc = false);

        /// <summary>
        /// 添加排序
        /// </summary>
        /// <param name="param">排序规则</param>
        IQuery<T> OrderBy(SortParam param);
    }
}
