using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 查找实体列表
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IFindAsync<T>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        Task<IList<T>> FindAsync<TQueryParameter>(IGenericQuery<T, TQueryParameter> query, CancellationToken cancellationToken = default)
            where TQueryParameter : GenericParameter<T>;

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="predicate">条件</param>
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        Task<IList<T>> FindPageAsync<TQueryParameter>(IPagingQuery<T, TQueryParameter> query, CancellationToken cancellationToken = default)
             where TQueryParameter : PageParameter<T>;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        Task<PageList<T>> FindPageListAsync<TQueryParameter>(IPagingQuery<T, TQueryParameter> query, CancellationToken cancellationToken = default)
             where TQueryParameter : PageParameter<T>;
    }
}
