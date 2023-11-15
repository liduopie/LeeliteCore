using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.DataDictionary.Models.DataItemAgg
{
    public static class DataItemCriteria
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static Criterion<DataItem> Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new TrueCriterion<DataItem>();

            keyword = keyword.ToLower();

            var valueCriterion = new DirectCriterion<DataItem>(c => c.Value.Contains(keyword));

            var criterion = valueCriterion;

            return criterion;
        }

        /// <summary>
        /// 数据类别查询
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        public static Criterion<DataItem> DataTypeId(string dataTypeId)
        {
            if (string.IsNullOrWhiteSpace(dataTypeId))
                return new TrueCriterion<DataItem>();

            var criterion = new DirectCriterion<DataItem>(c => c.DataTypeId == dataTypeId);

            return criterion;
        }
    }
}
