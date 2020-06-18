using Leelite.Framework.Data.Query.Paging;

namespace Leelite.Framework.Data.Query.Parameters
{
    /// <summary>
    /// 分页查询参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PageParameter<T> : GenericParameter<T>, IPaging
    {
        /// <inheritdoc/>
        public PageParam Pager { get; set; }

        public PageParameter()
        {
            Pager = new PageParam();
        }
    }
}
