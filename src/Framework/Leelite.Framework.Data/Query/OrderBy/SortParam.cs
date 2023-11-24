namespace Leelite.Framework.Data.Query.OrderBy
{
    /// <summary>
    /// 排序规则
    /// </summary>
    public class SortParam
    {
        /// <summary>
        /// 构建排序规则
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="desc">排序方式,true倒序、false正序。</param>
        public SortParam(string name, bool desc = false)
        {
            FiledName = name;
            if (desc)
                SortType = SortType.Desc;
            else
                SortType = SortType.Asc;
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string FiledName { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public SortType SortType { get; set; }
    }
}
