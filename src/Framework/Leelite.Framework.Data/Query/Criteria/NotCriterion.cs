using System;
using System.Linq;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// 规约逻辑非运算
    /// </summary>
    /// <typeparam name="T">检查规约的实体类型</typeparam>
    public sealed class NotCriterion<T> : Criterion<T>
    {
        #region Members

        Expression<Func<T, bool>> _OriginalCriteria;

        #endregion

        #region Constructor

        /// <summary>
        /// 非运算构造函数
        /// </summary>
        /// <param name="originalCriterion">原规约参数</param>
        public NotCriterion(ICriterion<T> originalCriterion)
        {

            if (originalCriterion == (ICriterion<T>)null)
                throw new ArgumentNullException("originalCriterion");

            _OriginalCriteria = originalCriterion.SatisfiedBy();
        }

        /// <summary>
        /// 非运算构造函数
        /// </summary>
        /// <param name="originalCriterion">原规约表达式</param>
        public NotCriterion(Expression<Func<T, bool>> originalCriterion)
        {
            if (originalCriterion == (Expression<Func<T, bool>>)null)
                throw new ArgumentNullException("originalCriterion");

            _OriginalCriteria = originalCriterion;
        }

        #endregion

        #region Override Criterion methods

        /// <summary>
        /// 重写SatisfiedBy(),参见<see cref="ICriterion{T}"/>
        /// </summary>
        /// <returns>返回非运算表达式</returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {

            return Expression.Lambda<Func<T, bool>>(Expression.Not(_OriginalCriteria.Body),
                                                         _OriginalCriteria.Parameters.Single());
        }

        #endregion
    }
}
