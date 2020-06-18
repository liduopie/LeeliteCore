using System;
using System.Threading.Tasks;
using Leelite.Framework.Service;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Framework.Models.Enabled
{

    /// <summary>
    /// 应用服务扩展
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 启用实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        public static void Enabled<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id)
            where TEntity : IAggregateRoot<TKey>, IEnabled
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Enabled();

            service.Repository.Update(entity);
        }

        /// <summary>
        /// 启用实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        public static async Task EnabledAsync<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id)
            where TEntity : IAggregateRoot<TKey>, IEnabled
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Enabled();

            await service.Repository.UpdateAsync(entity);
        }

        /// <summary>
        /// 禁用实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        public static void Disabled<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id)
            where TEntity : IAggregateRoot<TKey>, IEnabled
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Disabled();

            service.Repository.Update(entity);
        }

        /// <summary>
        /// 禁用实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        public static async Task DisabledAsync<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id)
            where TEntity : IAggregateRoot<TKey>, IEnabled
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Disabled();

            await service.Repository.UpdateAsync(entity);
        }
    }
}
