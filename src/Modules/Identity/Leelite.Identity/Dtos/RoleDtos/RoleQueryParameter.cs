using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.RoleAgg;

namespace Leelite.Identity.Dtos.RoleDtos
{
    public class RoleQueryParameter : PageParameter<Role>, IKeyword
    {
        public string Keyword { get; set; }

        public override Expression<Func<Role, bool>> SatisfiedBy()
        {
            Criterion<Role> c = new TrueCriterion<Role>();

            if (string.IsNullOrEmpty(Keyword))
                c &= RoleCriteria.Keyword(Keyword);

            return c.SatisfiedBy();
        }
    }
}
