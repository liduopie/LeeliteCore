using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.OrderBy
{
    public static class OrderByExtensions
    {
        /// <summary>
        /// 根据排序条件构建IQueryable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="source">原始IQueryable</param>
        /// <param name="sortItems">排序参数</param>
        /// <returns>返回IQueryable</returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IList<SortParam> sortItems)
        {
            var expression = source.Expression;
            int count = 0;

            foreach (var item in sortItems)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.Property(parameter, item.FiledName);
                var method = item.SortType == SortType.Desc ?
                    count == 0 ? "OrderByDescending" : "ThenByDescending" :
                    count == 0 ? "OrderBy" : "ThenBy";
                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                count++;
            }
            return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
        }
    }
}
