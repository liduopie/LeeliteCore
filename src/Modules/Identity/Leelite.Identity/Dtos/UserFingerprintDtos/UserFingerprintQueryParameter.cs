using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Identity.Models.UserFingerprintAgg;

namespace Leelite.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintQueryParameter : PageParameter<UserFingerprint>
    {
        public UserFingerprintQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<UserFingerprint, bool>> SatisfiedBy()
        {
            Criterion<UserFingerprint> c = new TrueCriterion<UserFingerprint>();

            return c.SatisfiedBy();
        }
    }
}

