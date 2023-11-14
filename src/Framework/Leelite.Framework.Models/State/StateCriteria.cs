using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Models.State
{
    public static class StateCriteria
    {
        /// <summary>
        /// 按状态查询
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TState">状态类型</typeparam>
        /// <param name="state">状态值</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> State<TEntity, TState>(TState state)
            where TEntity : IState<TState>
        {
            return new DirectCriterion<TEntity>(c => c.State.Equals(state));
        }
    }
}
