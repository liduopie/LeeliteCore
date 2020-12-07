using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Leelite.Core.Validation;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 添加实体
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IAddAsync<T>
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task AddAsync([Valid] T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task AddRangeAsync([Valid] IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
