using System.Linq.Expressions;

using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Models.Tree;

namespace Leelite.DataCategory.Dtos.CategoryDtos
{
    public class CategoryQueryParameter : PageParameter<Category>, IKeyword
    {
        public CategoryQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public string Keyword { get; set; }

        public int CategoryTypeId { get; set; }

        public long? ParentId { get; set; }

        public int? Level { get; set; }

        public bool? IsEnabled { get; set; }

        public string Path { get; set; }

        public override Expression<Func<Category, bool>> SatisfiedBy()
        {
            Criterion<Category> c = new TrueCriterion<Category>();

            if (string.IsNullOrEmpty(Keyword))
                c &= CategoryCriteria.Keyword(Keyword);

            if (CategoryTypeId > 0)
                c &= CategoryCriteria.CategoryTypeId(CategoryTypeId);

            if (ParentId != null)
                c &= TreeCriteria.Children<Category, long>(ParentId.Value);

            if (Level != null)
                c &= TreeCriteria.Level<Category, long>(Level.Value);

            if (IsEnabled != null)
                c &= CategoryCriteria.IsEnabled(IsEnabled.Value);

            if (!string.IsNullOrEmpty(Path))
                c &= TreeCriteria.Path<Category, long>(Path);

            return c.SatisfiedBy();
        }
    }
}
