using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// 描述规约
    /// <remarks>
    /// 重写创建并、或、非运算规约方法。
    /// 附加重写并、或运算。
    /// framework更新后，C#不能直接重写并、或运算,但是允许重写false和true运算。参见<see cref="http://msdn.microsoft.com/en-us/library/aa691312(VS.71).aspx"/>
    /// </remarks>
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class Criterion<T> : ICriterion<T>
    {
        #region ICriterion<T> Members

        /// <summary>
        /// 是否满足规约
        /// </summary>
        /// <returns>表达式是否满足规约</returns>
        public abstract Expression<Func<T, bool>> SatisfiedBy();

        #endregion

        #region Override Operators

        /// <summary>
        /// 并运算
        /// </summary>
        /// <param name="leftSideCriterion">并运算左参数</param>
        /// <param name="rightSideCriterion">并运算右是参数</param>
        /// <returns>组合成新的规约</returns>
        public static Criterion<T> operator &(Criterion<T> leftSideCriterion, Criterion<T> rightSideCriterion)
        {
            return new AndCriterion<T>(leftSideCriterion, rightSideCriterion);
        }

        /// <summary>
        /// 或运算
        /// </summary>
        /// <param name="leftSideCriterion">或运算左参数</param>
        /// <param name="rightSideCriterion">或运算右参数</param>
        /// <returns>组合成新的规约 </returns>
        public static Criterion<T> operator |(Criterion<T> leftSideCriterion, Criterion<T> rightSideCriterion)
        {
            return new OrCriterion<T>(leftSideCriterion, rightSideCriterion);
        }

        /// <summary>
        /// 非运算
        /// </summary>
        /// <param name="Criterion">否定规约</param>
        /// <returns>否定规约,产生新的规约</returns>
        public static Criterion<T> operator !(Criterion<T> Criterion)
        {
            return new NotCriterion<T>(Criterion);
        }

        /// <summary>
        /// 重写false运算,仅支持并、或运算
        /// </summary>
        /// <param name="Criterion">规约实例</param>
        /// <returns>返回false</returns>
        public static bool operator false(Criterion<T> Criterion)
        {
            return false;
        }

        /// <summary>
        /// 重写true运算，仅支持并、或运算
        /// </summary>
        /// <param name="Criterion">规约实例</param>
        /// <returns>返回false</returns>
        public static bool operator true(Criterion<T> Criterion)
        {
            return true;
        }

        #endregion
    }
}
