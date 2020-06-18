using System;
using System.Threading;
using System.Threading.Tasks;
using Leelite.Framework.Domain.Model;

namespace Leelite.Framework.Domain.Repository
{
    public static partial class RepositoryExtensions
    {
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">标识</param>
        public static TEntity FindById<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, TKey id)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            var result = repository.Find(c => c.Id.Equals(id));

            if (result.Count > 0)
                return result[0];
            else
                return default;
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public static async Task<TEntity> FindByIdAsync<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, TKey id, CancellationToken cancellationToken = default)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            var result = await repository.FindAsync(c => c.Id.Equals(id), cancellationToken);

            if (result.Count > 0)
                return result[0];
            else
                return default;
        }
    }
}
