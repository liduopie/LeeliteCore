using System;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 通过标识判断是否存在
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IExists<T>
    {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate">条件</param>
        bool Exists(Expression<Func<T, bool>> predicate = null);
    }
}
