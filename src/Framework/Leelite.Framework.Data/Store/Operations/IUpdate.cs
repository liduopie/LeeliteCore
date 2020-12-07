using System.Collections.Generic;

using Leelite.Core.Validation;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 修改实体
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IUpdate<T>
    {
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update([Valid] T entity);

        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void UpdateRange([Valid] IEnumerable<T> entities);
    }
}
