using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Models.SoftDelete;
using Leelite.MessageCenter.Models.MessageAgg;

using System;
using System.Linq.Expressions;

namespace Leelite.MessageCenter.Dtos.MessageDtos
{
    public class MessageQueryParameter : PageParameter<Message>,
        ISoftDeleteParameter
    {
        public MessageQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public string Keyword { get; set; }
        public DateTime? StartCreateTime { get; set; }
        public DateTime? EndCreateTime { get; set; }
        public bool? GenerateRecord { get; set; }
        public bool? ReadState { get; set; }
        public bool? Delivered { get; set; }
        public bool? Expired { get; set; }
        public bool? Deleted { get; set; }
        public int MessageTypeId { get; set; }

        public override Expression<Func<Message, bool>> SatisfiedBy()
        {
            Criterion<Message> c = new TrueCriterion<Message>();

            if (string.IsNullOrEmpty(Keyword))
                c &= MessageCriteria.Keyword(Keyword);

            if (StartCreateTime != null || EndCreateTime != null)
            {
                if (StartCreateTime == null) StartCreateTime = DateTime.MinValue;

                if (EndCreateTime == null) EndCreateTime = DateTime.MaxValue;

                c &= MessageCriteria.CreateTimeRange(StartCreateTime.Value, EndCreateTime.Value);
            }

            if (MessageTypeId > 0)
                c &= MessageCriteria.MessageType(MessageTypeId);

            if (GenerateRecord.HasValue)
            {
                c &= MessageCriteria.GenerateRecord(GenerateRecord.Value);
            }

            if (ReadState.HasValue)
            {
                if (ReadState.Value)
                    c &= MessageCriteria.Read();
                else
                    c &= MessageCriteria.UnRead();
            }

            if (Delivered != null)
                c &= MessageCriteria.Delivered(Delivered.Value);

            if (Expired != null)
                c &= MessageCriteria.Expired(Expired.Value);

            if (Deleted != null)
                c &= MessageCriteria.Deleted(Deleted.Value);

            return c.SatisfiedBy();
        }
    }
}

