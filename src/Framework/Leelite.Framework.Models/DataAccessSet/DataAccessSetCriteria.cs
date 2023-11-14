using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Models.DataAccessSet
{
    public static class DataAccessSetCriteria
    {
        /// <summary>
        /// 按照所有者查找
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="ownerId">所有者Id</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> OwnerId<TEntity, TKey>(string ownerId)
            where TEntity : IDataAccessSet<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.OwnerId == ownerId);
        }

        /// <summary>
        /// 按照权限查找
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="permission">权限值</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> Permission<TEntity, TKey>(string permission)
            where TEntity : IAccessItem<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.Permission == permission);
        }

        /// <summary>
        /// 按照访问人查找
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="userId">用户Id</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> AccessUser<TEntity, TKey>(string userId)
            where TEntity : IAccessItem<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.UserId == userId);
        }

        /// <summary>
        /// 按照访问分组查找
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="groupId">分组Id</param>
        /// <returns></returns>
        public static Criterion<TEntity> AccessGroup<TEntity, TKey>(string groupId)
            where TEntity : IAccessItem<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.GroupId == groupId);
        }

        /// <summary>
        /// 按照访问角色查找
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public static Criterion<TEntity> AccessRole<TEntity, TKey>(string roleId)
            where TEntity : IAccessItem<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.RoleId == roleId);
        }
    }
}
