using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 查找实体列表
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IFind<T>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        IList<T> Find<TQueryParameter>(IGenericQuery<T, TQueryParameter> query) where TQueryParameter : GenericParameter<T>;

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="predicate">条件</param>
        IList<T> Find(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        IList<T> FindPage<TQueryParameter>(IPagingQuery<T, TQueryParameter> query) where TQueryParameter : PageParameter<T>;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        PageList<T> FindPageList<TQueryParameter>(IPagingQuery<T, TQueryParameter> query) where TQueryParameter : PageParameter<T>;
    }
}
