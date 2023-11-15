using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service;

namespace Leelite.Framework.Models.State
{
    /// <summary>
    /// 应用服务扩展
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 更改状态
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <typeparam name="TState">状态</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        /// <param name="state">状态</param>
        public static void ChangeState<TEntity, TKey, TState>(this IService<TEntity, TKey> service, TKey id, TState state)
            where TEntity : IAggregateRoot<TKey>, IState<TState>
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.State = state;

            service.Repository.Update(entity);
        }

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <typeparam name="TState">状态</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        /// <param name="state">状态</param>
        public static async Task ChangeStateAsync<TEntity, TKey, TState>(this IService<TEntity, TKey> service, TKey id, TState state)
            where TEntity : IAggregateRoot<TKey>, IState<TState>
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.State = state;

            await service.Repository.UpdateAsync(entity);
        }
    }
}
