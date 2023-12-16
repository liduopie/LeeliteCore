using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.RoleClaimAgg;

namespace Leelite.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimQueryParameter : PageParameter<RoleClaim>
    {
        public RoleClaimQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<RoleClaim, bool>> SatisfiedBy()
        {
            Criterion<RoleClaim> c = new TrueCriterion<RoleClaim>();

            return c.SatisfiedBy();
        }
    }
}

