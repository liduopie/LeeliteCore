using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.MessageCenter.Models.MessageTypeAgg;

namespace Leelite.MessageCenter.Dtos.MessageTypeDtos
{
    public class MessageTypeQueryParameter : PageParameter<MessageType>
    {
        public MessageTypeQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<MessageType, bool>> SatisfiedBy()
        {
            Criterion<MessageType> c = new TrueCriterion<MessageType>();

            return c.SatisfiedBy();
        }
    }
}

