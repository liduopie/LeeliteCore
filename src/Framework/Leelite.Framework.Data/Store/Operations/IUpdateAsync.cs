using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Leelite.Core.Validation;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 修改实体
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IUpdateAsync<T>
    {
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task UpdateAsync([Valid] T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        Task UpdateRangeAsync([Valid] IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
