using System;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Models.Enabled;
using Leelite.Samples.ModuleSample.Models.BlogAgg;

namespace Leelite.Samples.ModuleSample.Dtos
{
    public class BlogQueryParameter : PageParameter<Blog>, IKeyword, IEnabledParameter
    {
        public string Keyword { get; set; }
        public bool? IsEnabled { get; set; }

        public BlogQueryParameter() : base() { }

        public override Expression<Func<Blog, bool>> SatisfiedBy()
        {
            Criterion<Blog> c = new TrueCriterion<Blog>();

            if (IsEnabled.HasValue)
                c &= IsEnabled.Value ? EnabledCriteria.Enabled<Blog>() : EnabledCriteria.Disabled<Blog>();

            if (string.IsNullOrEmpty(Keyword))
                c &= BlogCriteria.Keyword(Keyword);

            return c.SatisfiedBy();
        }
    }
}
