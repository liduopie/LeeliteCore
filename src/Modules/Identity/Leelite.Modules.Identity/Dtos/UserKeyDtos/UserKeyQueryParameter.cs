using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Identity.Models.UserKeyAgg;

namespace Leelite.Modules.Identity.Dtos.UserKeyDtos
{
    public class UserKeyQueryParameter : PageParameter<UserKey>
    {
        public override Expression<Func<UserKey, bool>> SatisfiedBy()
        {
            Criterion<UserKey> c = new TrueCriterion<UserKey>();

            return c.SatisfiedBy();
        }
    }
}

