using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Identity.Models.UserTokenAgg;

namespace Leelite.Modules.Identity.Dtos.UserTokenDtos
{
    public class UserTokenQueryParameter : PageParameter<UserToken>
    {
        public override Expression<Func<UserToken, bool>> SatisfiedBy()
        {
            Criterion<UserToken> c = new TrueCriterion<UserToken>();

            return c.SatisfiedBy();
        }
    }
}

