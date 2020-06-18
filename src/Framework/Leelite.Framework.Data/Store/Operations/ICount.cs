using System;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Store.Operations
{
    /// <summary>
    /// 查找数量
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface ICount<T>
    {
        /// <summary>
        /// 查找数量
        /// </summary>
        /// <param name="predicate">条件</param>
        int Count(Expression<Func<T, bool>> predicate = null);
    }
}
