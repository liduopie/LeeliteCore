using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Models.PushRecordAgg;

namespace Leelite.Modules.MessageCenter.Models.PushRecordAgg.Dtos.PushRecordDtos
{
    public class PushRecordQueryParameter : PageParameter<PushRecord>
    {
        public override Expression<Func<PushRecord, bool>> SatisfiedBy()
        {
            Criterion<PushRecord> c = new TrueCriterion<PushRecord>();

            return c.SatisfiedBy();
        }
    }
}

