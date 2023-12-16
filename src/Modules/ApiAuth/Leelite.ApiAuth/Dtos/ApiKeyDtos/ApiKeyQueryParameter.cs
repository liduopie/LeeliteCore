using System.Linq.Expressions;

using Leelite.ApiAuth.Models.ApiKeyAgg;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.ApiAuth.Dtos.ApiKeyDtos
{
    public class ApiKeyQueryParameter : PageParameter<ApiKey>
    {
        public long UserId { get; set; }

        public override Expression<Func<ApiKey, bool>> SatisfiedBy()
        {
            Criterion<ApiKey> c = new TrueCriterion<ApiKey>();

            if (UserId != 0)
            {
                c &= ApiKeyCriteria.UserId(UserId);
            }

            return c.SatisfiedBy();
        }
    }
}

