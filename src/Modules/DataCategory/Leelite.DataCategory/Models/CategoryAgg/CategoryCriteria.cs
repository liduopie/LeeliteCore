using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.DataCategory.Models.CategoryAgg
{
    public static class CategoryCriteria
    {
        public static Criterion<Category> Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new TrueCriterion<Category>();

            keyword = keyword.ToLower();

            var nameCriterion = new DirectCriterion<Category>(c => c.Name.Contains(keyword));
            var descriptionCriterion = new DirectCriterion<Category>(c => c.Description.Contains(keyword));

            var criterion = nameCriterion && descriptionCriterion;

            return criterion;
        }

        public static Criterion<Category> CategoryTypeId(int categoryTypeId)
        {
            var criterion = new DirectCriterion<Category>(c => c.CategoryTypeId == categoryTypeId);

            return criterion;
        }

        public static Criterion<Category> IsEnabled(bool isEnabled)
        {
            var criterion = new DirectCriterion<Category>(c => c.IsEnabled == isEnabled);

            return criterion;
        }
    }
}
