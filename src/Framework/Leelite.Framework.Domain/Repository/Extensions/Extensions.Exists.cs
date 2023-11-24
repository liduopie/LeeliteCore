using Leelite.Framework.Domain.Model;

namespace Leelite.Framework.Domain.Repository
{
    public static partial class RepositoryExtensions
    {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        public static bool Exists<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, params TKey[] ids)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return repository.Exists(c => ids.Contains(c.Id));
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        public static async Task<bool> ExistsAsync<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, params TKey[] ids)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await repository.ExistsAsync(c => ids.Contains(c.Id));
        }
    }
}
