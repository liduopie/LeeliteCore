using System.Linq.Expressions;

using LinqToElasticSearch;

using Nest;

namespace Leelite.Framework.Data.Store
{
    public abstract class ElasticAbstractStore<TEntity> : IAbstractStore<TEntity>
        where TEntity : class
    {
        private readonly IClientProvider _clientProvider;
        protected string _indexName;

        public ElasticAbstractStore(IClientProvider clientProvider)
        {
            _indexName = typeof(TEntity).Name.ToLower();
            _clientProvider = clientProvider;
        }

        protected ElasticClient ElasticClient
        {
            get
            {
                return _clientProvider.GetClient(_indexName);
            }
        }

        public void AsNoTracking()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> predicate = null)
        {
            var elasticQueryable = new ElasticQueryable<TEntity>(ElasticClient, _indexName);

            return elasticQueryable;
        }

        public void AsTracking()
        {
            throw new NotImplementedException();
        }
    }
}
