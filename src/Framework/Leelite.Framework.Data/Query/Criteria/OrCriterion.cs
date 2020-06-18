using System;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// 规约逻辑或运算
    /// </summary>
    /// <typeparam name="T">检查规约的实体类型</typeparam>
    public sealed class OrCriterion<T> : CompositeCriterion<T>
    {
        #region Members

        private ICriterion<T> _RightSideCriterion = null;
        private ICriterion<T> _LeftSideCriterion = null;

        #endregion

        #region Public Constructor

        /// <summary>
        /// 或运算默认构造方法
        /// </summary>
        /// <param name="leftSide">或运算左参数</param>
        /// <param name="rightSide">或运算右参数</param>
        public OrCriterion(ICriterion<T> leftSide, ICriterion<T> rightSide)
        {
            if (leftSide == null)
                throw new ArgumentNullException("leftSide");

            if (rightSide == null)
                throw new ArgumentNullException("rightSide");

            this._LeftSideCriterion = leftSide;
            this._RightSideCriterion = rightSide;
        }

        #endregion

        #region Composite Criterion overrides

        /// <summary>
        /// 或运算左参数
        /// </summary>
        public override ICriterion<T> LeftSideCriterion
        {
            get { return _LeftSideCriterion; }
        }

        /// <summary>
        /// 或运算右参数
        /// </summary>
        public override ICriterion<T> RightSideCriterion
        {
            get { return _RightSideCriterion; }
        }

        /// <summary>
        ///  重写SatisfiedBy(),参见<see cref="ICriterion{T}"/>
        /// </summary>
        /// <returns>返回或运算后的新规约表达式</returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = _LeftSideCriterion.SatisfiedBy();
            Expression<Func<T, bool>> right = _RightSideCriterion.SatisfiedBy();

            return (left.Or(right));
        }

        #endregion
    }
}
