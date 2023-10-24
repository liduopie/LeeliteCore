using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.MessageCenter.Models.PushRecordAgg;

namespace Leelite.MessageCenter.Dtos.PushRecordDtos
{
    public class PushRecordQueryParameter : PageParameter<PushRecord>
    {
        public PushState[] States { get; set; }
        public bool? Expired { get; set; }
        public IList<string> Topics { get; set; }

        public override Expression<Func<PushRecord, bool>> SatisfiedBy()
        {
            Criterion<PushRecord> c = new TrueCriterion<PushRecord>();

            if (States != null && States.Length > 0)
                c &= PushRecordCriteria.PushStates(States);

            if (Expired != null)
                c &= PushRecordCriteria.Expired(Expired.Value);

            if (Topics != null && Topics.Count > 0)
                c &= PushRecordCriteria.Topics(Topics);

            return c.SatisfiedBy();
        }
    }
}

