using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;

namespace Leelite.Modules.MessageCenter.Dtos.PushPlatformDtos
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

