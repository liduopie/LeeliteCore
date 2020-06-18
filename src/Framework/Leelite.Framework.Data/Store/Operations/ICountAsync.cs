using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 查找数量
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface ICountAsync<T>
    {
        /// <summary>
        /// 查找数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default);
    }
}
