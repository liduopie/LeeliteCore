using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.Framework.Data.Query.OrderBy;

namespace Leelite.DataDictionary.Dtos.DataTypeDtos
{
    public class DataTypeQueryParameter : PageParameter<DataType>
    {
        public DataTypeQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<DataType, bool>> SatisfiedBy()
        {
            Criterion<DataType> c = new TrueCriterion<DataType>();

            return c.SatisfiedBy();
        }
    }
}

