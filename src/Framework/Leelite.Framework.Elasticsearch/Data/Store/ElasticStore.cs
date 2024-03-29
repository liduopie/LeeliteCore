﻿using Leelite.Core.Validation;
using Leelite.Framework.Domain.Model;

using Nest;

namespace Leelite.Framework.Data.Store
{
    public class ElasticStore<TEntity> : ElasticQueryStore<TEntity>, IStore<TEntity>
        where TEntity : class
    {
        public ElasticStore(IClientProvider clientProvider) : base(clientProvider)
        {
        }

        /// <inheritdoc/>
        public void Add([Valid] TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            var response = ElasticClient.IndexDocument(entity);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public async Task AddAsync([Valid] TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                return;
            }

            var response = await ElasticClient.IndexDocumentAsync(entity);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public void AddRange([Valid] IEnumerable<TEntity> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                return;
            }

            var response = ElasticClient.IndexMany(entities);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync([Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null || entities.Count() == 0)
            {
                return;
            }

            var response = await ElasticClient.IndexManyAsync(entities);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            var response = ElasticClient.Delete<TEntity>(entity);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                return;
            }

            var response = await ElasticClient.DeleteAsync<TEntity>(entity);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                return;
            }

            var response = ElasticClient.DeleteMany(entities);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null || entities.Count() == 0)
            {
                return;
            }

            var response = await ElasticClient.DeleteManyAsync(entities);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public void Update([Valid] TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            var response = ElasticClient.Update<TEntity>(entity, p => p.Doc(entity));
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public async Task UpdateAsync([Valid] TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                return;
            }

            var response = await ElasticClient.UpdateAsync<TEntity>(entity, p => p.Doc(entity));
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public void UpdateRange([Valid] IEnumerable<TEntity> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                return;
            }

            var response = ElasticClient.IndexMany(entities);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }

        /// <inheritdoc/>
        public async Task UpdateRangeAsync([Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null || entities.Count() == 0)
            {
                return;
            }

            var response = await ElasticClient.IndexManyAsync(entities);
            if (!response.IsValid)
            {
                throw new Exception(response.ServerError.ToString());
            }
        }
    }
}
