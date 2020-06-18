using System;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.RangeCriteria
{
    /// <summary>
    /// 日期范围过滤条件 - 包含时间
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class DateTimeRangeCriterion<T, TProperty> : RangeCriterion<T, TProperty, DateTime> where T : class
    {
        /// <summary>
        /// 初始化日期范围过滤条件 - 包含时间
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public DateTimeRangeCriterion(Expression<Func<T, TProperty>> propertyExpression, DateTime? min, DateTime? max, Boundary boundary = Boundary.Both)
            : base(propertyExpression, min, max, boundary)
        {
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        protected override bool IsMinGreaterMax(DateTime? min, DateTime? max)
        {
            return min > max;
        }
    }
}
