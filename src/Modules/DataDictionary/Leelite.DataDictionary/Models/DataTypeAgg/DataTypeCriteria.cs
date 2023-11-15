using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.DataDictionary.Models.DataTypeAgg
{
    public static class DataTypeCriteria
    {
        public static Criterion<DataType> Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new TrueCriterion<DataType>();

            keyword = keyword.ToLower();

            var nameCriterion = new DirectCriterion<DataType>(c => c.Name.Contains(keyword));

            var criterion = nameCriterion;

            return criterion;
        }
    }
}
