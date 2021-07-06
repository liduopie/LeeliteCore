using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Message.Models.MessageTypeAgg.Models.MessageTypeAgg;

namespace Leelite.Modules.Message.Models.MessageTypeAgg.Dtos.MessageTypeDtos
{
    public class MessageTypeQueryParameter : PageParameter<MessageType>
    {
        public override Expression<Func<MessageType, bool>> SatisfiedBy()
        {
            Criterion<MessageType> c = new TrueCriterion<MessageType>();

            return c.SatisfiedBy();
        }
    }
}

