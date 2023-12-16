using System;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.MessageCenter.Models.PushPlatformAgg;

namespace Leelite.MessageCenter.Dtos.PushPlatformDtos
{
    public class PushPlatformQueryParameter : PageParameter<PushPlatform>
    {
        public PushPlatformQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<PushPlatform, bool>> SatisfiedBy()
        {
            Criterion<PushPlatform> c = new TrueCriterion<PushPlatform>();

            return c.SatisfiedBy();
        }
    }
}

