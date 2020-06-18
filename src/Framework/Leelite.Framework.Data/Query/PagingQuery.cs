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
    /// <typeparam name="TQueryParameter">查询参数</typeparam>
    public class PagingQuery<T, TQueryParameter> : GenericQuery<T, TQueryParameter>, IPagingQuery<T, TQueryParameter>
        where TQueryParameter : PageParameter<T>
    {
        protected PageParam Pager { get; set; }

        public PagingQuery(TQueryParameter parameter) : base(parameter)
        {
            if (parameter.Pager == null)
                Pager = new PageParam();
            else
                Pager = parameter.Pager;
        }

        /// <inheritdoc/>
        public void Paging(int page, int pageSize)
        {
            Pager.Page = page;
            Pager.PageSize = pageSize;
        }

        /// <inheritdoc/>
        public IQueryable<T> BuildPageQueryable(IQueryable<T> source)
        {
            var pageList = BuildQueryable(source);

            if (Pager.GetSkipCount() > 0)
                pageList = pageList.Skip(Pager.GetSkipCount());
            if (Pager.PageSize > 0)
                pageList = pageList.Take(Pager.PageSize);

            return pageList;
        }

        /// <inheritdoc/>
        public IList<T> PageQuery(IQueryable<T> source)
        {
            var pageList = BuildPageQueryable(source);

            return pageList.ToList();
        }

        /// <inheritdoc/>
        public PageList<T> PageListQuery(IQueryable<T> source)
        {
            var pageList = BuildPageQueryable(source);

            // 总行数
            var totalCount = BuildQueryable(source).LongCount();

            return new PageList<T>(pageList.ToList(), Pager, Parameter.SortItems, totalCount);
        }
    }
}
