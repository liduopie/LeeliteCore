using Leelite.Core.Aspects;
using Leelite.Core.Validation;

using Microsoft.EntityFrameworkCore;

namespace Leelite.Framework.Data.Store
{
    [CommonAspects]
    public abstract class EFStore<TEntity> : EFQueryStore<TEntity>, IStore<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 初始化查询存储器
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public EFStore(DbContext dbcontext) : base(dbcontext) { }

        /// <inheritdoc/>
        public void Add([Valid] TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbSet.Add(entity);

            DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task AddAsync([Valid] TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await DbSet.AddAsync(entity, cancellationToken);

            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public void AddRange([Valid] IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbSet.AddRange(entities);

            DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync([Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await DbSet.AddRangeAsync(entities, cancellationToken);

            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public void Remove(TEntity entity)
        {
            if (entity == null)
                return;

            DbSet.Remove(entity);

            DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                return;

            DbSet.Remove(entity);

            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                return;

            DbSet.RemoveRange(entities);

            DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            DbSet.RemoveRange(entities);

            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public void Update([Valid] TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbContext.Entry(entity).State = EntityState.Modified;

            DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync([Valid] TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbContext.Entry(entity).State = EntityState.Modified;

            await DbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public void UpdateRange([Valid] IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
                DbContext.Entry(entity).State = EntityState.Modified;

            DbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task UpdateRangeAsync([Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
                DbContext.Entry(entity).State = EntityState.Modified;

            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
