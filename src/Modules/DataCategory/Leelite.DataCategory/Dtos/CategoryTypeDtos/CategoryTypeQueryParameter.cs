using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.DataCategory.Models.CategoryTypeAgg;

namespace Leelite.DataCategory.Dtos.CategoryTypeDtos
{
    public class CategoryTypeQueryParameter : PageParameter<CategoryType>
    {
        public override Expression<Func<CategoryType, bool>> SatisfiedBy()
        {
            Criterion<CategoryType> c = new TrueCriterion<CategoryType>();

            return c.SatisfiedBy();
        }
    }
}

