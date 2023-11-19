using AutoMapper;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Events;

namespace Leelite.Framework.Service.Commands
{
    public class UpdateCommandHandler<TUpdateRequest, TDto, TEntity, TKey> : ICommandHandler<UpdateCommand<TUpdateRequest, TDto, TEntity, TKey>, TDto>
         where TEntity : IAggregateRoot<TKey>
         where TKey : IEquatable<TKey>
    {
        private readonly IRepository<TEntity, TKey> _repository;
        private readonly IDomainEventBus _domainEventBus;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(
            IRepository<TEntity, TKey> repository,
            IDomainEventBus domainEventBus,
            IMapper mapper)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
            _mapper = mapper;
        }

        public async Task<TDto> Handle(UpdateCommand<TUpdateRequest, TDto, TEntity, TKey> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request.Source);

            await _repository.UpdateAsync(entity);

            await _domainEventBus.PublishAsync(new ModifiedEvent<TEntity>(entity));

            return _mapper.Map<TDto>(entity);
        }
    }
}
