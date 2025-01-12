using Leelite.Framework.Domain.Aggregate;

namespace Leelite.DataCategory.Models.CategoryTypeAgg
{
    public class CategoryType : AggregateRoot<int>
    {
        /// <summary>
        /// 分类编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }
    }
}
