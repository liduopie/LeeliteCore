using Leelite.Framework.Domain.Aggregate;

namespace Leelite.DataCategory.Models.CategoryTypeAgg
{
    public class CategoryType : AggregateRoot<int>
    {
        public string Name { get; set; }
    }
}
