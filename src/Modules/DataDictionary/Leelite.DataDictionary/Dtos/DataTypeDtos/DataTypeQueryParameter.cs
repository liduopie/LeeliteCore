using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.DataDictionary.Models.DataTypeAgg;

namespace Leelite.DataDictionary.Dtos.DataTypeDtos
{
    public class DataTypeQueryParameter : PageParameter<DataType>
    {
        public override Expression<Func<DataType, bool>> SatisfiedBy()
        {
            Criterion<DataType> c = new TrueCriterion<DataType>();

            return c.SatisfiedBy();
        }
    }
}

