using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Message.Models.SessionAgg.Models.SessionAgg;

namespace Leelite.Modules.Message.Models.SessionAgg.Dtos.SessionDtos
{
    public class SessionQueryParameter : PageParameter<Session>
    {
        public override Expression<Func<Session, bool>> SatisfiedBy()
        {
            Criterion<Session> c = new TrueCriterion<Session>();

            return c.SatisfiedBy();
        }
    }
}

