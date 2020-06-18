using System.Collections.Generic;
using Leelite.Commons.Validation;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 添加实体
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IAdd<T>
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Add([Valid] T entity);

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void AddRange([Valid] IEnumerable<T> entities);
    }
}
