using Leelite.Framework.Domain.Model;

namespace Leelite.Framework.Domain.Repository
{
    public static partial class RepositoryExtensions
    {
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        public static void Remove<TEntity, TKey>(this IRepository<TEntity, TKey> repository, TKey id)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            var entity = repository.FindById(id);

            repository.Remove(entity);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        public static void Remove<TEntity, TKey>(this IRepository<TEntity, TKey> repository, IEnumerable<TKey> ids)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            var entities = repository.Find(c => ids.Contains(c.Id));

            repository.RemoveRange(entities);
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public static async Task RemoveAsync<TEntity, TKey>(this IRepository<TEntity, TKey> repository, TKey id, CancellationToken cancellationToken = default)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            var entity = await repository.FindByIdAsync(id, cancellationToken);

            await repository.RemoveAsync(entity, cancellationToken);
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public static async Task RemoveAsync<TEntity, TKey>(this IRepository<TEntity, TKey> repository, IEnumerable<TKey> ids, CancellationToken cancellationToken = default)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {

            var entities = await repository.FindAsync(c => ids.Contains(c.Id), cancellationToken);

            await repository.RemoveRangeAsync(entities, cancellationToken);
        }
    }
}
