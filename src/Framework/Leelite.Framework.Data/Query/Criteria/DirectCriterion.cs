using System;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// 直接规约是一个从lambda表达式获得规约的简单实现
    /// </summary>
    /// <typeparam name="T">检查规约的实体类型</typeparam>
    public sealed class DirectCriterion<T> : Criterion<T>
    {
        #region Members

        Expression<Func<T, bool>> _MatchingCriteria;

        #endregion

        #region Constructor

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="matchingCriteria">匹配规约</param>
        public DirectCriterion(Expression<Func<T, bool>> matchingCriteria)
        {
            if (matchingCriteria == null)
                throw new ArgumentNullException("matchingCriteria");

            _MatchingCriteria = matchingCriteria;
        }

        #endregion

        #region Override

        /// <summary>
        /// 重写SatisfiedBy()
        /// </summary>
        /// <returns>返回表达式</returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            return _MatchingCriteria;
        }

        #endregion
    }
}
