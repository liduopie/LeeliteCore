using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Identity.Models.UserClaimAgg;

namespace Leelite.Modules.Identity.Dtos.UserClaimDtos
{
    public class UserClaimQueryParameter : PageParameter<UserClaim>
    {
        public override Expression<Func<UserClaim, bool>> SatisfiedBy()
        {
            Criterion<UserClaim> c = new TrueCriterion<UserClaim>();

            return c.SatisfiedBy();
        }
    }
}

