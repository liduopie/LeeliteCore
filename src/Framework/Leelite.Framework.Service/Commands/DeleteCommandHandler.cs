using System;
using System.Threading;
using System.Threading.Tasks;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Events;

namespace Leelite.Framework.Service.Commands
{
    public class DeleteCommandHandler<TEntity, TKey> : ICommandHandler<DeleteCommand<TEntity, TKey>, bool>
         where TEntity : IAggregateRoot<TKey>
         where TKey : IEquatable<TKey>
    {
        private readonly IRepository<TEntity, TKey> _repository;
        private readonly IDomainEventBus _domainEventBus;

        public DeleteCommandHandler(
            IRepository<TEntity, TKey> repository,
            IDomainEventBus domainEventBus)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
        }

        public async Task<bool> Handle(DeleteCommand<TEntity, TKey> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindByIdAsync(request.Source, cancellationToken);

            await _repository.RemoveAsync(entity);

            await _domainEventBus.PublishAsync(new DeletedEvent<TEntity>(entity));

            return true;
        }
    }
}
