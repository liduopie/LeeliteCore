using System;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.MessageCenter.Models.SessionAgg;

namespace Leelite.MessageCenter.Dtos.SessionDtos
{
    public class SessionQueryParameter : PageParameter<Session>
    {
        public SessionQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public string Keyword { get; set; }
        public CompleteState[] States { get; set; }
        public DateTime? StartCreateTime { get; set; }
        public DateTime? EndCreateTime { get; set; }
        public bool? Expired { get; set; }
        public int? MessageTypeId { get; set; }

        public override Expression<Func<Session, bool>> SatisfiedBy()
        {
            Criterion<Session> c = new TrueCriterion<Session>();

            if (string.IsNullOrEmpty(Keyword))
                c &= SessionCriteria.Keyword(Keyword);

            if (StartCreateTime != null || EndCreateTime != null)
            {
                if (StartCreateTime == null) StartCreateTime = DateTime.MinValue;

                if (EndCreateTime == null) EndCreateTime = DateTime.MaxValue;

                c &= SessionCriteria.CreateTimeRange(StartCreateTime.Value, EndCreateTime.Value);
            }

            if (States != null && States.Length > 0)
                c &= SessionCriteria.CompleteStates(States);

            if (Expired != null)
                c &= SessionCriteria.Expired(Expired.Value);

            if (MessageTypeId.HasValue)
                c &= SessionCriteria.MessageType(MessageTypeId.Value);

            return c.SatisfiedBy();
        }
    }
}

