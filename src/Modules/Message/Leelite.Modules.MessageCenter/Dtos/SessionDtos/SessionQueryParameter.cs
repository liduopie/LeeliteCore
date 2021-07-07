using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.MessageCenter.Models.SessionAgg;

namespace Leelite.Modules.MessageCenter.Dtos.SessionDtos
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

