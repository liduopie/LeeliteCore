using System;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;

namespace Leelite.Modules.MessageCenter.Dtos.PushRecordDtos
{
    public class PushRecordQueryParameter : PageParameter<PushRecord>
    {
        public PushState[] States { get; set; }
        public bool? Expired { get; set; }

        public override Expression<Func<PushRecord, bool>> SatisfiedBy()
        {
            Criterion<PushRecord> c = new TrueCriterion<PushRecord>();

            if (States != null && States.Length > 0)
                c &= PushRecordCriteria.PushStates(States);

            if (Expired != null)
                c &= PushRecordCriteria.Expired(Expired.Value);

            return c.SatisfiedBy();
        }
    }
}

