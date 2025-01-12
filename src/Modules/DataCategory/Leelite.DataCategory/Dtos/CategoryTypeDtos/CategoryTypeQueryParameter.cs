using System.Linq.Expressions;

using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.DataCategory.Dtos.CategoryTypeDtos
{
    public class CategoryTypeQueryParameter : PageParameter<CategoryType>
    {
        public CategoryTypeQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public string Keyword { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public override Expression<Func<CategoryType, bool>> SatisfiedBy()
        {
            Criterion<CategoryType> c = new TrueCriterion<CategoryType>();

            if (!string.IsNullOrEmpty(Keyword))
            {
                c &= CategoryTypeCriteria.Keyword(Keyword);
            }

            if (!string.IsNullOrEmpty(Code))
            {
                c &= CategoryTypeCriteria.Code(Code);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                c &= CategoryTypeCriteria.Name(Name);
            }

            return c.SatisfiedBy();
        }
    }
}

