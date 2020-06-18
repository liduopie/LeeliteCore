using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 移除实体
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IRemoveAsync<T>
    {
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
