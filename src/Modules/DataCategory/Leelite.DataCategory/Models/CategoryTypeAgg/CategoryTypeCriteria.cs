using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.DataCategory.Models.CategoryTypeAgg
{
    public static class CategoryTypeCriteria
    {
        public static Criterion<CategoryType> Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new TrueCriterion<CategoryType>();

            keyword = keyword.ToLower();

            var nameCriterion = new DirectCriterion<CategoryType>(c => c.Name.Contains(keyword));

            var criterion = nameCriterion;

            return criterion;
        }
    }
}
