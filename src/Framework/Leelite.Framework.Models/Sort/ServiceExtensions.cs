using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service;

namespace Leelite.Framework.Models.Sort
{
    /// <summary>
    /// 应用服务扩展
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 更新排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        /// <param name="sort">顺序值</param>
        public static void UpdateSort<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id, int sort)
            where TEntity : IAggregateRoot<TKey>, ISort
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Sort = sort;

            service.Repository.Update(entity);
        }

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="id">标识</param>
        /// <param name="sort">顺序值</param>
        public static async Task UpdateSortAsync<TEntity, TKey>(this IService<TEntity, TKey> service, TKey id, int sort)
            where TEntity : IAggregateRoot<TKey>, ISort
            where TKey : IEquatable<TKey>
        {
            var entity = service.Repository.FindById(id);

            entity.Sort = sort;

            await service.Repository.UpdateAsync(entity);
        }
    }
}
