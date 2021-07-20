using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.MessageCenter.Models.SessionAgg;

using System;
using System.Linq.Expressions;

namespace Leelite.Modules.MessageCenter.Dtos.SessionDtos
{
    public class SessionQueryParameter : PageParameter<Session>
    {
        public string Keyword { get; set; }
        public CompleteState[] States { get; set; }
        public DateTime StartCreateTime { get; set; }
        public DateTime EndCreateTime { get; set; }
        public bool IgnoreExpires { get; set; }

        public override Expression<Func<Session, bool>> SatisfiedBy()
        {
            Criterion<Session> c = new TrueCriterion<Session>();

            if (string.IsNullOrEmpty(Keyword))
                c &= SessionCriteria.Keyword(Keyword);

            if (StartCreateTime != null || EndCreateTime != null)
            {
                if (StartCreateTime == null) StartCreateTime = DateTime.MinValue;

                if (EndCreateTime == null) EndCreateTime = DateTime.MaxValue;

                c &= SessionCriteria.CreateTimeRange(StartCreateTime, EndCreateTime);
            }

            if (States.Length > 0)
                c &= SessionCriteria.CompleteStates(States);

            if (!IgnoreExpires)
                c &= SessionCriteria.Unexpired();

            return c.SatisfiedBy();
        }
    }
}

