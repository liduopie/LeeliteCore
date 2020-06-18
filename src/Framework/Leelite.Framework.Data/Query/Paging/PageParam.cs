namespace Leelite.Framework.Data.Query.Paging
{
    /// <summary>
    /// 分页查询参数
    /// </summary>Pager
    public class PageParam
    {
        /// <summary>
        /// 页数，即第几页，从1开始
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 获取跳过的行数
        /// </summary>
        public int GetSkipCount()
        {
            return (Page - 1) * PageSize;
        }

        public PageParam()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}
