using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 通过标识判断是否存在
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IExistsAsync<T>
    {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate">条件</param>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default);
    }
}
