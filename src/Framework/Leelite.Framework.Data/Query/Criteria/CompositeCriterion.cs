namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// 组合规约基类
    /// </summary>
    /// <typeparam name="T">检查规约的实体类型</typeparam>
    public abstract class CompositeCriterion<T> : Criterion<T>
    {
        #region Properties

        /// <summary>
        /// 组合规约的左参数
        /// </summary>
        public abstract ICriterion<T> LeftSideCriterion { get; }

        /// <summary>
        /// 组合规约的右参数
        /// </summary>
        public abstract ICriterion<T> RightSideCriterion { get; }

        #endregion
    }
}
