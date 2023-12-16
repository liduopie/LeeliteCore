using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.ApiAuth.Models.ApiKeyAgg
{
    public static class ApiKeyCriteria
    {
        public static Criterion<ApiKey> UserId(long userId)
        {
            if (userId == 0)
                return new TrueCriterion<ApiKey>();

            var userIdCriterion = new DirectCriterion<ApiKey>(c => c.UserId == userId);
            return userIdCriterion;
        }

        public static Criterion<ApiKey> Key(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return new TrueCriterion<ApiKey>();

            var keyCriterion = new DirectCriterion<ApiKey>(c => c.Key == key);
            return keyCriterion;
        }
    }
}
