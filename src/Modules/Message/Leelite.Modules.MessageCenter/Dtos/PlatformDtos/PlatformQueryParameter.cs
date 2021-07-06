using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Models.PlatformAgg;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.Dtos.PlatformDtos
{
    public class PlatformQueryParameter : PageParameter<Platform>
    {
        public override Expression<Func<Platform, bool>> SatisfiedBy()
        {
            Criterion<Platform> c = new TrueCriterion<Platform>();

            return c.SatisfiedBy();
        }
    }
}

