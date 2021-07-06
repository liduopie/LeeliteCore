using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Message.Models.MessageAgg.Models.MessageAgg;

namespace Leelite.Modules.Message.Models.MessageAgg.Dtos.MessageDtos
{
    public class MessageQueryParameter : PageParameter<Message>
    {
        public override Expression<Func<Message, bool>> SatisfiedBy()
        {
            Criterion<Message> c = new TrueCriterion<Message>();

            return c.SatisfiedBy();
        }
    }
}

