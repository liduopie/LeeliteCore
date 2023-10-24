using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// False 规约
    /// </summary>
    /// <typeparam name="T">检查规约的实体类型</typeparam>
    public class FalseCriterion<T> : Criterion<T>
    {
        #region Criterion overrides

        /// <summary>
        /// 重写抽象方法,参见 <see cref="ICriterion{T}"/>
        /// </summary>
        /// <returns>返回表达式</returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            //Create "result variable" transform adhoc execution plan in prepared plan
            //for more info: http://geeks.ms/blogs/unai/2010/07/91/ef-4-0-performance-tips-1.aspx
            bool result = false;

            Expression<Func<T, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}
