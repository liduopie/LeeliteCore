using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Commands;
using Leelite.Framework.Service.Events;

namespace Leelite.DataCategory.CommandHandlers
{
    public class CategoryDeleteCommandHandler : ICommandHandler<DeleteCommand<Category, long>, bool>
    {
        private readonly IRepository<Category, long> _repository;
        private readonly IDomainEventBus _domainEventBus;

        public CategoryDeleteCommandHandler(
            IRepository<Category, long> repository,
            IDomainEventBus domainEventBus)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
        }

        public async Task<bool> Handle(DeleteCommand<Category, long> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindByIdAsync(request.Source, cancellationToken);

            if (entity == null) return true;

            var children = await _repository.FindAsync(c => c.Path.StartsWith(entity.Path));

            if (children.Count > 0)
            {
                throw new Exception("存在子分类，不能删除。");
            }

            await _repository.RemoveAsync(entity);

            await _domainEventBus.PublishAsync(new DeletedEvent<Category>(entity));

            return true;
        }
    }
}
