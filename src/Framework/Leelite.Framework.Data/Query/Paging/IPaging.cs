namespace Leelite.Framework.Data.Query.Paging
{
    /// <summary>
    /// 分页接口
    /// </summary>
    public interface IPaging
    {
        /// <summary>
        /// 分页条件
        /// </summary>
        PageParam Pager { get; set; }
    }
}
