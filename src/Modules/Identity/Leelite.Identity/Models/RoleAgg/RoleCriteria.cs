using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Identity.Models.RoleAgg
{
    public static class RoleCriteria
    {
        public static Criterion<Role> Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new TrueCriterion<Role>();

            keyword = keyword.ToLower();

            var nameCriterion = new DirectCriterion<Role>(c => c.Name.Contains(keyword));
            var descriptionCriterion = new DirectCriterion<Role>(c => c.Description.Contains(keyword));

            var criterion = nameCriterion && descriptionCriterion;

            return criterion;
        }
    }
}
