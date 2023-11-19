using AutoMapper;

using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Commands;
using Leelite.Framework.Service.Events;

namespace Leelite.DataCategory.CommandHandlers
{
    public class CategoryUpdateCommandHandler : ICommandHandler<UpdateCommand<CategoryUpdateRequest, CategoryDto, Category, long>, CategoryDto>
    {
        private readonly IRepository<Category, long> _repository;
        private readonly IDomainEventBus _domainEventBus;
        private readonly IMapper _mapper;

        public CategoryUpdateCommandHandler(
            IRepository<Category, long> repository,
            IDomainEventBus domainEventBus,
            IMapper mapper)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCommand<CategoryUpdateRequest, CategoryDto, Category, long> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Category>(request.Source);

            await _repository.UpdateAsync(entity);

            if (entity.ParentId > 0)
            {
                var parent = await _repository.FindByIdAsync(entity.ParentId);

                entity.Path = parent.Path + "\\" + entity.Id;
            }
            else
            {
                entity.Path = entity.Id.ToString();
            }

            await _repository.UpdateAsync(entity);

            await _domainEventBus.PublishAsync(new ModifiedEvent<Category>(entity));

            return _mapper.Map<CategoryDto>(entity);
        }
    }
}
