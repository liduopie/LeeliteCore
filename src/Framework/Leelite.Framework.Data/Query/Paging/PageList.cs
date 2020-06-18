using System.Collections.Generic;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Data.Query.Paging
{
    /// <summary>
    /// 分页集合
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    public class PageList<T>
    {
        public PageList() { }

        public PageList(IList<T> data, PageParam paper, IList<SortParam> sortItems, long total)
        {
            Page = paper.Page;
            PageSize = paper.PageSize;

            TotalCount = total;

            if (PageSize > 0)
                PageCount = TotalCount / PageSize;

            SortItems = sortItems;

            Data = data;
        }

        /// <summary>
        /// 页索引，即第几页，从1开始
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public long PageCount { get; set; }

        /// <summary>
        /// 排序条件
        /// </summary>
        public IList<SortParam> SortItems { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public IList<T> Data { get; set; }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">索引</param>
        public T this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }
    }
}
