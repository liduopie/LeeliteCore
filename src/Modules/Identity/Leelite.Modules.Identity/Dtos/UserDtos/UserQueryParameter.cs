using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Identity.Models.UserAgg;

namespace Leelite.Modules.Identity.Dtos.UserDtos
{
    public class UserQueryParameter : PageParameter<User>
    {
        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            Criterion<User> c = new TrueCriterion<User>();

            return c.SatisfiedBy();
        }
    }
}

