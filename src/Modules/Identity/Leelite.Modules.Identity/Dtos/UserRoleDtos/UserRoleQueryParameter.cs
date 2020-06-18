using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Identity.Models.UserRoleAgg;

namespace Leelite.Modules.Identity.Dtos.UserRoleDtos
{
    public class UserRoleQueryParameter : PageParameter<UserRole>
    {
        public override Expression<Func<UserRole, bool>> SatisfiedBy()
        {
            Criterion<UserRole> c = new TrueCriterion<UserRole>();

            return c.SatisfiedBy();
        }
    }
}

