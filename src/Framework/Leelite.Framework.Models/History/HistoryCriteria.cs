using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Models.History
{
    public static class HistoryCriteria
    {
        /// <summary>
        /// 根据修改人查询实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">实体标识类型</typeparam>
        /// <typeparam name="TUserKey">用户标识类型</typeparam>
        /// <param name="userId">用户Id</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> ModifierId<TEntity, TKey, TUserKey>(TUserKey userId)
            where TEntity : IHistoryRecord<TUserKey>
        {
            return new DirectCriterion<TEntity>(c => c.Modifier.Equals(userId));
        }
    }
}
