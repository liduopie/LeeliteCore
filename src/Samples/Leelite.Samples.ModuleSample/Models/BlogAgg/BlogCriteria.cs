using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Samples.ModuleSample.Models.BlogAgg
{
    public static class BlogCriteria
    {
        public static Criterion<Blog> Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new TrueCriterion<Blog>();

            keyword = keyword.ToLower();

            var urlCriterion = new DirectCriterion<Blog>(c => c.Url.ToLower().Contains(keyword));

            return urlCriterion;
        }
    }
}
