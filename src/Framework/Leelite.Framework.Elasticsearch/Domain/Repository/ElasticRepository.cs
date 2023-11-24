using Leelite.Framework.Data.Store;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Framework.Domain.Repository
{
    public class ElasticRepository<TEntity, TKey> : ElasticStore<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {
        public ElasticRepository(IClientProvider clientProvider) : base(clientProvider)
        {
        }

        /// <inheritdoc/>
        public TEntity FindById(TKey id)
        {
            var result = ElasticClient.Get<TEntity>(id.ToString());

            if (result.IsValid)
                return result.Source;
            else
                return default;
        }

        /// <inheritdoc/>
        public async Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var result = await ElasticClient.GetAsync<TEntity>(id.ToString(), ct: cancellationToken);

            if (result.IsValid)
                return result.Source;
            else
                return default;
        }
    }
}
