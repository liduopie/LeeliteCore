using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Models.Audit;

namespace Leelite.Framework.Models.Enabled
{
    public static class AuditCriteria
    {
        /// <summary>
        /// 根据创建人查询实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TUserKey">用户标识类型</typeparam>
        /// <param name="userId">用户Id</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> CreateId<TEntity, TUserKey>(TUserKey userId)
            where TEntity : ICreationAudited<TUserKey>
        {
            return new DirectCriterion<TEntity>(c => c.CreatorId.Equals(userId));
        }

        /// <summary>
        /// 根据最后修改人查询实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TUserKey">用户标识类型</typeparam>
        /// <param name="userId">用户Id</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> LastModifierId<TEntity, TUserKey>(TUserKey userId)
            where TEntity : IModificationAudited<TUserKey>
        {
            return new DirectCriterion<TEntity>(c => c.LastModifierId.Equals(userId));
        }

        /// <summary>
        /// 根据删除人查询实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TUserKey">用户标识类型</typeparam>
        /// <param name="userId">用户Id</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> DeleterId<TEntity, TUserKey>(TUserKey userId)
            where TEntity : ISoftDeletionAudited<TUserKey>
        {
            return new DirectCriterion<TEntity>(c => c.DeleterId.Equals(userId));
        }
    }
}
