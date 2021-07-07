using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.MessageCenter.Models.MessageAgg;

namespace Leelite.Modules.MessageCenter.Dtos.MessageDtos
{
    public class MessageQueryParameter : PageParameter<Models.MessageAgg.Message>
    {
        public override Expression<Func<Models.MessageAgg.Message, bool>> SatisfiedBy()
        {
            Criterion<Models.MessageAgg.Message> c = new TrueCriterion<Models.MessageAgg.Message>();

            return c.SatisfiedBy();
        }
    }
}

