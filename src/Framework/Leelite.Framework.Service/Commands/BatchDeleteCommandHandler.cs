using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Events;

namespace Leelite.Framework.Service.Commands
{
    public class BatchDeleteCommandHandler<TEntity, TKey> : ICommandHandler<BatchDeleteCommand<TEntity, TKey>, bool>
         where TEntity : IAggregateRoot<TKey>
         where TKey : IEquatable<TKey>
    {
        private readonly IRepository<TEntity, TKey> _repository;
        private readonly IDomainEventBus _domainEventBus;

        public BatchDeleteCommandHandler(
            IRepository<TEntity, TKey> repository,
            IDomainEventBus domainEventBus)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
        }

        public async Task<bool> Handle(BatchDeleteCommand<TEntity, TKey> request, CancellationToken cancellationToken)
        {
            var entities = await _repository.FindAsync(c => request.Source.Contains(c.Id), cancellationToken);

            await _repository.RemoveRangeAsync(entities, cancellationToken);

            foreach (var item in entities)
            {
                await _domainEventBus.PublishAsync(new DeletedEvent<TEntity>(item));
            }

            return true;
        }
    }
}
