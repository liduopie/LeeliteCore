using System.Linq.Expressions;

using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;

using Microsoft.EntityFrameworkCore;

namespace Leelite.Framework.Data.Store
{
    /// <summary>
    /// 查询存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public abstract class EFQueryStore<TEntity> : EFAbstractStore<TEntity>, IQueryStore<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 初始化查询存储器
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public EFQueryStore(DbContext dbcontext) : base(dbcontext) { }

        #region Count

        /// <inheritdoc/>
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return AsQueryable().Count();

            return AsQueryable().Count(predicate);
        }

        /// <inheritdoc/>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            if (predicate == null)
                return await AsQueryable().CountAsync();

            return await AsQueryable().CountAsync(predicate);
        }

        #endregion

        #region Exists

        /// <inheritdoc/>
        public bool Exists(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return false;
            return AsQueryable().Any(predicate);
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            if (predicate == null)
                return false;
            return await AsQueryable().AnyAsync(predicate);
        }

        #endregion

        #region Find

        /// <inheritdoc/>
        public IList<TEntity> Find<TQueryParameter>(IGenericQuery<TEntity, TQueryParameter> query)
            where TQueryParameter : GenericParameter<TEntity>
        {
            return query.Query(AsQueryable());
        }

        /// <inheritdoc/>
        public IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return AsQueryable().ToList();
            else
                return AsQueryable().Where(predicate).ToList();
        }

        /// <inheritdoc/>
        public IList<TEntity> FindPage<TQueryParameter>(IPagingQuery<TEntity, TQueryParameter> query)
             where TQueryParameter : PageParameter<TEntity>
        {
            return query.PageQuery(AsQueryable());
        }

        /// <inheritdoc/>
        public PageList<TEntity> FindPageList<TQueryParameter>(IPagingQuery<TEntity, TQueryParameter> query)
            where TQueryParameter : PageParameter<TEntity>
        {
            return query.PageListQuery(AsQueryable());
        }

        /// <inheritdoc/>
        public async Task<IList<TEntity>> FindAsync<TQueryParameter>(IGenericQuery<TEntity, TQueryParameter> query, CancellationToken cancellationToken = default)
            where TQueryParameter : GenericParameter<TEntity>
        {
            return await query.QueryAsync(AsQueryable(), cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            return await AsQueryable().Where(predicate).ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IList<TEntity>> FindPageAsync<TQueryParameter>(IPagingQuery<TEntity, TQueryParameter> query, CancellationToken cancellationToken = default)
            where TQueryParameter : PageParameter<TEntity>
        {
            return await query.PageQueryAsync(AsQueryable(), cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PageList<TEntity>> FindPageListAsync<TQueryParameter>(IPagingQuery<TEntity, TQueryParameter> query, CancellationToken cancellationToken = default)
            where TQueryParameter : PageParameter<TEntity>
        {
            return await query.PageListQueryAsync(AsQueryable());
        }

        #endregion
    }
}
