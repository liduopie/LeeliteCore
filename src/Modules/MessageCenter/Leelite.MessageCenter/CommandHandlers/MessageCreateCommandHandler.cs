using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Commands;
using Leelite.Framework.Service.Events;
using Leelite.MessageCenter.Dtos.MessageDtos;
using Leelite.MessageCenter.Models.MessageAgg;

namespace Leelite.MessageCenter.CommandHandlers
{
    public class MessageCreateCommandHandler : ICommandHandler<CreateCommand<MessageCreateRequest, MessageDto, Message, long>, MessageDto>
    {
        private readonly IRepository<Message, long> _repository;
        private readonly IDomainEventBus _domainEventBus;
        private readonly IMapper _mapper;

        public MessageCreateCommandHandler(
            IRepository<Message, long> repository,
            IDomainEventBus domainEventBus,
            IMapper mapper)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
            _mapper = mapper;
        }

        public async Task<MessageDto> Handle(CreateCommand<MessageCreateRequest, MessageDto, Message, long> request, CancellationToken cancellationToken)
        {
            // dto转实体，赋默认值
            var entity = _mapper.Map<Message>(request.Source);

            entity.ReadState = false;
            entity.DeliveryState = false;
            entity.IsDeleted = false;
            entity.CreateTime = DateTime.Now;

            // 添加实体
            await _repository.AddAsync(entity);

            await _domainEventBus.PublishAsync(new CreatedEvent<Message>(entity));

            // 实体转dto
            return _mapper.Map<MessageDto>(entity);
        }

    }

}
