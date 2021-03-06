using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Identity.Models.UserFingerprintAgg;

namespace Leelite.Modules.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintQueryParameter : PageParameter<UserFingerprint>
    {
        public override Expression<Func<UserFingerprint, bool>> SatisfiedBy()
        {
            Criterion<UserFingerprint> c = new TrueCriterion<UserFingerprint>();

            return c.SatisfiedBy();
        }
    }
}

