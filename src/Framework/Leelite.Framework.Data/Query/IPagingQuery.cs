using System.Collections.Generic;
using System.Linq;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Data.Query
{
    /// <summary>
    /// 分页查询对象
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IPagingQuery<T, TQueryParameter> : IGenericQuery<T, TQueryParameter>
        where TQueryParameter : PageParameter<T>
    {
        /// <summary>
        /// 设置分页参数
        /// </summary>
        /// <param name="page">页数，即第几页，从1开始</param>
        /// <param name="pageSize">每页显示行数</param>
        void Paging(int page, int pageSize);

        /// <summary>
        /// 准备分页查询
        /// </summary>
        /// <param name="source">原始IQueryable</param>
        /// <returns>返回带有过滤条件的IQueryable</returns>
        IQueryable<T> BuildPageQueryable(IQueryable<T> source);

        /// <summary>
        /// 执行分页查询
        /// </summary>
        /// <param name="source">原始IQueryable</param>
        /// <returns>返回数据集合</returns>
        IList<T> PageQuery(IQueryable<T> source);

        /// <summary>
        /// 执行分页查询
        /// </summary>
        /// <param name="source">原始IQueryable</param>
        /// <returns>返回分页集合</returns>
        PageList<T> PageListQuery(IQueryable<T> source);
    }
}
