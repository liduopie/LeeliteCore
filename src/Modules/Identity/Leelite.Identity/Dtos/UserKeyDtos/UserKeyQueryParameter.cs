using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.UserKeyAgg;

namespace Leelite.Identity.Dtos.UserKeyDtos
{
    public class UserKeyQueryParameter : PageParameter<UserKey>
    {
        public UserKeyQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<UserKey, bool>> SatisfiedBy()
        {
            Criterion<UserKey> c = new TrueCriterion<UserKey>();

            return c.SatisfiedBy();
        }
    }
}

