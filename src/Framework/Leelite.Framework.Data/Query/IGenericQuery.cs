using System.Collections.Generic;
using System.Linq;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Data.Query
{
    /// <summary>
    /// 一般条件查询对象
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IGenericQuery<T, TQueryParameter> : IQuery<T>
        where TQueryParameter : GenericParameter<T>
    {
        TQueryParameter Parameter { get; set; }

        /// <summary>
        /// 准备查询
        /// </summary>
        /// <param name="source">原始IQueryable</param>
        /// <returns>返回带有过滤条件的IQueryable</returns>
        IQueryable<T> BuildQueryable(IQueryable<T> source);

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="source">原始IQueryable</param>
        /// <returns>返回实体集合。</returns>
        IList<T> Query(IQueryable<T> source);
    }
}
