using System.Linq.Expressions;

namespace Leelite.Framework.Data.Store
{
    public interface IAbstractStore<T>
    {

        /// <summary>
        /// 将Store设置为不跟踪查询结果状态。
        /// </summary>
        void AsNoTracking();

        /// <summary>
        /// 将Store设置为跟踪查询结果状态。
        /// </summary>
        void AsTracking();

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>返回IQueryable</returns>
        IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate = null);
    }
}
