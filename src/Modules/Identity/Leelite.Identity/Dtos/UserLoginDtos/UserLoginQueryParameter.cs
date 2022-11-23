using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.UserLoginAgg;

namespace Leelite.Identity.Dtos.UserLoginDtos
{
    public class UserLoginQueryParameter : PageParameter<UserLogin>
    {
        public override Expression<Func<UserLogin, bool>> SatisfiedBy()
        {
            Criterion<UserLogin> c = new TrueCriterion<UserLogin>();

            return c.SatisfiedBy();
        }
    }
}

