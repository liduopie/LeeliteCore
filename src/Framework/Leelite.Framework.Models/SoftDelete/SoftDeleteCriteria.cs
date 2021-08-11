using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Models.SoftDelete
{
    public static class SoftDeleteCriteria
    {
        /// <summary>
        /// 查寻已删除实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>返回已删除条件</returns>
        public static Criterion<TEntity> Deleted<TEntity>()
            where TEntity : ISoftDelete
        {
            return new DirectCriterion<TEntity>(c => c.IsDeleted == true);
        }

        /// <summary>
        /// 查寻未删除实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <returns>返回未删除条件</returns>
        public static Criterion<TEntity> NotDelete<TEntity>()
            where TEntity : ISoftDelete
        {
            return new DirectCriterion<TEntity>(c => c.IsDeleted == false);
        }
    }
}
