using System;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.UserTokenAgg;

namespace Leelite.Identity.Dtos.UserTokenDtos
{
    public class UserTokenQueryParameter : PageParameter<UserToken>
    {
        public UserTokenQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<UserToken, bool>> SatisfiedBy()
        {
            Criterion<UserToken> c = new TrueCriterion<UserToken>();

            return c.SatisfiedBy();
        }
    }
}

