using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Events;

namespace Leelite.Framework.Service.Commands
{
    public class BatchSaveCommandHandler<TDto, TEntity, TKey> : ICommandHandler<BatchSaveCommand<TDto, TEntity, TKey>, IList<TDto>>
        where TEntity : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly IRepository<TEntity, TKey> _repository;
        private readonly IDomainEventBus _domainEventBus;
        private readonly IMapper _mapper;
        public BatchSaveCommandHandler(
            IRepository<TEntity, TKey> repository,
            IDomainEventBus domainEventBus,
            IMapper mapper)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
            _mapper = mapper;
        }

        public async Task<IList<TDto>> Handle(BatchSaveCommand<TDto, TEntity, TKey> request, CancellationToken cancellationToken)
        {
            var addEntities = _mapper.Map<IList<TEntity>>(request.AddList);
            var updateEntities = _mapper.Map<IList<TEntity>>(request.UpdateList);
            var deleteEntities = _mapper.Map<IList<TEntity>>(request.DeleteList);

            await _repository.AddRangeAsync(addEntities);

            foreach (var item in addEntities)
            {
                await _domainEventBus.PublishAsync(new CreatedEvent<TEntity>(item));
            }

            await _repository.UpdateRangeAsync(updateEntities);

            foreach (var item in updateEntities)
            {
                await _domainEventBus.PublishAsync(new ModifiedEvent<TEntity>(item));
            }

            await _repository.RemoveRangeAsync(deleteEntities);

            foreach (var item in deleteEntities)
            {
                await _domainEventBus.PublishAsync(new DeletedEvent<TEntity>(item));
            }

            var result = addEntities.Union(updateEntities);

            return _mapper.Map<IList<TDto>>(result);
        }
    }
}
