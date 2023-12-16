using AutoMapper;

using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Models.ApiKeyAgg;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Commands;
using Leelite.Framework.Service.Events;

namespace Leelite.ApiAuth.CommandHandlers.WordLibraryHandlers
{
    public class ApiKeyCreateCommandHandler : ICommandHandler<CreateCommand<ApiKeyCreateRequest, ApiKeyDto, ApiKey, long>, ApiKeyDto>
    {
        private readonly IRepository<ApiKey, long> _repository;
        private readonly IDomainEventBus _domainEventBus;
        private readonly IMapper _mapper;

        public ApiKeyCreateCommandHandler(
            IRepository<ApiKey, long> repository,
            IDomainEventBus domainEventBus,
            IMapper mapper)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
            _mapper = mapper;
        }

        public async Task<ApiKeyDto> Handle(CreateCommand<ApiKeyCreateRequest, ApiKeyDto, ApiKey, long> request, CancellationToken cancellationToken)
        {
            // dto转实体，赋默认值
            var entity = _mapper.Map<ApiKey>(request.Source);

            // 生成一个随机字符串
            entity.Key = Guid.NewGuid().ToString("N");

            // 添加实体
            await _repository.AddAsync(entity);

            await _domainEventBus.PublishAsync(new CreatedEvent<ApiKey>(entity));

            // 实体转dto
            return _mapper.Map<ApiKeyDto>(entity);
        }
    }
}
