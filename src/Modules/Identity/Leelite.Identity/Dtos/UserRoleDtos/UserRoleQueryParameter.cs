using System;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.UserRoleAgg;

namespace Leelite.Identity.Dtos.UserRoleDtos
{
    public class UserRoleQueryParameter : PageParameter<UserRole>
    {
        public UserRoleQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<UserRole, bool>> SatisfiedBy()
        {
            Criterion<UserRole> c = new TrueCriterion<UserRole>();

            return c.SatisfiedBy();
        }
    }
}

