using Leelite.Framework.Domain.Model;

namespace Leelite.Framework.Domain.Repository
{
    public static partial class RepositoryExtensions
    {
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        public static IList<TEntity> FindByIds<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, params TKey[] ids)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return repository.FindByIds(ids);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        public static IList<TEntity> FindByIds<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, IEnumerable<TKey> ids)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return repository.Find(c => ids.Contains(c.Id));
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        public static IList<TEntity> FindByIds<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, string ids)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            var idList = Commons.Helpers.Convert.ToList<TKey>(ids);
            return repository.FindByIds(idList);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        public static async Task<IList<TEntity>> FindByIdsAsync<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, params TKey[] ids)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await repository.FindByIdsAsync(ids);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <param name="cancellationToken">取消令牌</param>
        public static async Task<IList<TEntity>> FindByIdsAsync<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, IEnumerable<TKey> ids, CancellationToken cancellationToken = default)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return await repository.FindAsync(c => ids.Contains(c.Id), cancellationToken);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        public static async Task<IList<TEntity>> FindByIdsAsync<TEntity, TKey>(this IQueryRepository<TEntity, TKey> repository, string ids, CancellationToken cancellationToken = default)
            where TEntity : IEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            var idList = Commons.Helpers.Convert.ToList<TKey>(ids);
            return await repository.FindByIdsAsync(idList, cancellationToken);
        }
    }
}
