using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service;

using System;
using System.Threading.Tasks;

namespace Leelite.Framework.Models.SoftDelete
{
    /// <summary>
    /// 应用服务扩展
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        public static void Delete<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id)
            where TEntity : IAggregateRoot<TKey>, ISoftDelete
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Delete();

            service.Repository.Update(entity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        public static async Task DeleteAsync<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id)
            where TEntity : IAggregateRoot<TKey>, ISoftDelete
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Delete();

            await service.Repository.UpdateAsync(entity);
        }

        /// <summary>
        /// 恢复实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        public static void Recover<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id)
            where TEntity : IAggregateRoot<TKey>, ISoftDelete
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Recover();

            service.Repository.Update(entity);
        }

        /// <summary>
        /// 恢复实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        public static async Task RecoverAsync<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id)
            where TEntity : IAggregateRoot<TKey>, ISoftDelete
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Recover();

            await service.Repository.UpdateAsync(entity);
        }
    }
}
