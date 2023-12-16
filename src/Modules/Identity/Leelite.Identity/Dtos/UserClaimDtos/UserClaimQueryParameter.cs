using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.UserClaimAgg;

namespace Leelite.Identity.Dtos.UserClaimDtos
{
    public class UserClaimQueryParameter : PageParameter<UserClaim>
    {
        public UserClaimQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<UserClaim, bool>> SatisfiedBy()
        {
            Criterion<UserClaim> c = new TrueCriterion<UserClaim>();

            return c.SatisfiedBy();
        }
    }
}

