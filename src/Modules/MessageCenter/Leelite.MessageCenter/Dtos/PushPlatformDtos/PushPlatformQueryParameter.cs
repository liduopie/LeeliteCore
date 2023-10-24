using System;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.MessageCenter.Models.PushPlatformAgg;

namespace Leelite.MessageCenter.Dtos.PushPlatformDtos
{
    public class PushPlatformQueryParameter : PageParameter<PushPlatform>
    {
        public override Expression<Func<PushPlatform, bool>> SatisfiedBy()
        {
            Criterion<PushPlatform> c = new TrueCriterion<PushPlatform>();

            return c.SatisfiedBy();
        }
    }
}

