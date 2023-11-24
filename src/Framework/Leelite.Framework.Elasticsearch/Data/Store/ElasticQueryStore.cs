using System.Linq.Expressions;

using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Data.Store
{
    public class ElasticQueryStore<TEntity> : ElasticAbstractStore<TEntity>, IQueryStore<TEntity>
        where TEntity : class
    {
        public ElasticQueryStore(IClientProvider clientProvider) : base(clientProvider)
        {
        }

        #region Count

        /// <inheritdoc/>
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return AsQueryable().Count();

            return AsQueryable().Count(predicate);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Find

        /// <inheritdoc/>
        public IList<TEntity> Find<TQueryParameter>(IGenericQuery<TEntity, TQueryParameter> query) where TQueryParameter : GenericParameter<TEntity>
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

        public Task<IList<TEntity>> FindAsync<TQueryParameter>(IGenericQuery<TEntity, TQueryParameter> query, CancellationToken cancellationToken = default)
            where TQueryParameter : GenericParameter<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IList<TEntity> FindPage<TQueryParameter>(IPagingQuery<TEntity, TQueryParameter> query) where TQueryParameter : PageParameter<TEntity>
        {
            return query.PageQuery(AsQueryable());
        }

        public Task<IList<TEntity>> FindPageAsync<TQueryParameter>(IPagingQuery<TEntity, TQueryParameter> query, CancellationToken cancellationToken = default) where TQueryParameter : PageParameter<TEntity>
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public PageList<TEntity> FindPageList<TQueryParameter>(IPagingQuery<TEntity, TQueryParameter> query) where TQueryParameter : PageParameter<TEntity>
        {
            return query.PageListQuery(AsQueryable());
        }

        public Task<PageList<TEntity>> FindPageListAsync<TQueryParameter>(IPagingQuery<TEntity, TQueryParameter> query, CancellationToken cancellationToken = default) where TQueryParameter : PageParameter<TEntity>
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
