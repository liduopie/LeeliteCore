using System;
using System.Linq.Expressions;

using Leelite.DataDictionary.Models.DataItemAgg;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.DataDictionary.Dtos.DataItemDtos
{
    public class DataItemQueryParameter : PageParameter<DataItem>
    {
        public string Keyword { get; set; }
        public string DataTypeId { get; set; }

        public override Expression<Func<DataItem, bool>> SatisfiedBy()
        {
            Criterion<DataItem> c = new TrueCriterion<DataItem>();

            if (!string.IsNullOrEmpty(Keyword))
            {
                c &= DataItemCriteria.Keyword(Keyword);
            }

            if (!string.IsNullOrEmpty(DataTypeId))
            {
                c &= DataItemCriteria.DataTypeId(DataTypeId);
            }

            return c.SatisfiedBy();
        }
    }
}

