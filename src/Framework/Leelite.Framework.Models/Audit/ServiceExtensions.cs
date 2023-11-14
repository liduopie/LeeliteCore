using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service;

namespace Leelite.Framework.Models.Audit
{

    /// <summary>
    /// 应用服务扩展
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 更新创建人
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <typeparam name="TUserKey">用户主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名称</param>
        public static void UpdateCreator<TEntity, TKey, TUserKey>(this IService<TEntity, TKey> service, TKey id, TUserKey userId, string userName)
            where TEntity : IAggregateRoot<TKey>, ICreationAudited<TUserKey>
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.AddCreator(userId, userName);

            service.Repository.Update(entity);
        }

        /// <summary>
        /// 更新修改人
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <typeparam name="TUserKey">用户主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名称</param>
        public static void UpdateModifier<TEntity, TKey, TUserKey>(this IService<TEntity, TKey> service, TKey id, TUserKey userId, string userName)
            where TEntity : IAggregateRoot<TKey>, IModificationAudited<TUserKey>
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.AddModifier(userId, userName);

            service.Repository.Update(entity);
        }

        /// <summary>
        /// 更新软删除人
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <typeparam name="TUserKey">用户主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名称</param>
        public static void UpdateDeleter<TEntity, TKey, TUserKey>(this IService<TEntity, TKey> service, TKey id, TUserKey userId, string userName)
            where TEntity : IAggregateRoot<TKey>, ISoftDeletionAudited<TUserKey>
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.AddDeleter(userId, userName);

            service.Repository.Update(entity);
        }
    }
}
