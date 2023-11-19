using System.Linq.Expressions;

using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.DataCategory.Dtos.CategoryTypeDtos
{
    public class CategoryTypeQueryParameter : PageParameter<CategoryType>
    {
        public string Keyword { get; set; }
        public string Name { get; set; }

        public override Expression<Func<CategoryType, bool>> SatisfiedBy()
        {
            Criterion<CategoryType> c = new TrueCriterion<CategoryType>();

            if (!string.IsNullOrEmpty(Keyword))
            {
                c &= CategoryTypeCriteria.Keyword(Keyword);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                c &= CategoryTypeCriteria.Name(Name);
            }

            return c.SatisfiedBy();
        }
    }
}

