using System.Collections.Generic;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 移除实体
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IRemove<T>
    {
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Remove(T entity);

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void RemoveRange(IEnumerable<T> entities);
    }
}
