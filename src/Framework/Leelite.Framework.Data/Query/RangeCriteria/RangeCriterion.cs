using System;
using System.Linq.Expressions;

using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Data.Query.RangeCriteria
{
    /// <summary>
    /// 范围过滤条件
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    /// <typeparam name="TValue">值类型</typeparam>
    public abstract class RangeCriterion<T, TProperty, TValue> : Criterion<T>
        where T : class
        where TValue : struct
    {
        /// <summary>
        /// 属性表达式
        /// </summary>
        private readonly Expression<Func<T, TProperty>> _propertyExpression;

        /// <summary>
        /// 最小值
        /// </summary>
        private TValue? _min;
        /// <summary>
        /// 最大值
        /// </summary>
        private TValue? _max;

        /// <summary>
        /// 包含边界
        /// </summary>
        private readonly Boundary _boundary;

        /// <summary>
        /// 初始化范围过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        protected RangeCriterion(Expression<Func<T, TProperty>> propertyExpression, TValue? min, TValue? max, Boundary boundary)
        {
            _propertyExpression = propertyExpression;
            _min = min;
            _max = max;
            _boundary = boundary;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Adjust(_min, _max);

            var left = CreateLeftExpression();
            var right = CreateRightExpression();

            Expression final = null;

            if (left != null & right != null)
            {
                final = Expression.AndAlso(left, right);
            }
            else if (left != null)
            {
                final = left;
            }
            else if (right != null)
            {
                final = right;
            }

            if (final != null)
                return Expression.Lambda<Func<T, bool>>(final, _propertyExpression.Parameters);
            else
                return null;
        }

        /// <summary>
        /// 当最小值大于最大值时进行校正
        /// </summary>
        private void Adjust(TValue? min, TValue? max)
        {
            if (IsMinGreaterMax(min, max) == false)
                return;
            _min = max;
            _max = min;
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        protected abstract bool IsMinGreaterMax(TValue? min, TValue? max);

        /// <summary>
        /// 创建左操作数，即 t => t.Property >= Min
        /// </summary>
        private Expression CreateLeftExpression()
        {
            if (_min == null)
                return null;

            ConstantExpression constExpr = Expression.Constant(GetMinValue(), typeof(TProperty));

            return CreateLeftOperator(_boundary)(_propertyExpression.Body, constExpr);
        }

        /// <summary>
        /// 创建左操作符
        /// </summary>
        protected virtual Func<Expression, Expression, Expression> CreateLeftOperator(Boundary? boundary)
        {
            switch (boundary)
            {
                case Boundary.Left:
                    return Expression.GreaterThanOrEqual;
                case Boundary.Both:
                    return Expression.GreaterThanOrEqual;
                default:
                    return Expression.GreaterThan;
            }
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        protected virtual TValue? GetMinValue()
        {
            return _min;
        }

        /// <summary>
        /// 创建右操作数，即 t => t.Property &lt;= Max
        /// </summary>
        private Expression CreateRightExpression()
        {
            if (_max == null)
                return null;

            ConstantExpression constExpr = Expression.Constant(GetMaxValue(), typeof(TProperty));

            return CreateRightOperator(_boundary)(_propertyExpression.Body, constExpr);
        }

        /// <summary>
        /// 创建右操作符
        /// </summary>
        protected virtual Func<Expression, Expression, Expression> CreateRightOperator(Boundary? boundary)
        {
            switch (boundary)
            {
                case Boundary.Right:
                    return Expression.LessThanOrEqual;
                case Boundary.Both:
                    return Expression.LessThanOrEqual;
                default:
                    return Expression.LessThan;
            }
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        protected virtual TValue? GetMaxValue()
        {
            return _max;
        }
    }
}
