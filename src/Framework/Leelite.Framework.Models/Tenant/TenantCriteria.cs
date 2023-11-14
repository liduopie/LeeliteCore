using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Models.Tenant
{
    public static class TenantCriteria
    {
        /// <summary>
        /// 按租户查找实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="tenantId">租户Id</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> TenantId<TEntity, TKey>(TKey tenantId)
            where TEntity : ITenant<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.TenantId.Equals(tenantId));
        }
    }
}
