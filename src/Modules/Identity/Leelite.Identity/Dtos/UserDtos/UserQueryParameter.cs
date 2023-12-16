using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.UserAgg;

namespace Leelite.Identity.Dtos.UserDtos
{
    public class UserQueryParameter : PageParameter<User>
    {
        public UserQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            Criterion<User> c = new TrueCriterion<User>();

            return c.SatisfiedBy();
        }
    }
}

