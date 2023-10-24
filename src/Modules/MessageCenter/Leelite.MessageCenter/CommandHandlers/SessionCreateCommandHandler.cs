using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Commands;
using Leelite.Framework.Service.Events;
using Leelite.MessageCenter.Dtos.SessionDtos;
using Leelite.MessageCenter.Models.SessionAgg;

namespace Leelite.MessageCenter.CommandHandlers
{
    public class SessionCreateCommandHandler : ICommandHandler<CreateCommand<SessionCreateRequest, SessionDto, Session, long>, SessionDto>
    {
        private readonly IRepository<Session, long> _repository;
        private readonly IDomainEventBus _domainEventBus;
        private readonly IMapper _mapper;


        public SessionCreateCommandHandler(
            IRepository<Session, long> repository,
            IDomainEventBus domainEventBus,
            IMapper mapper)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
            _mapper = mapper;
        }

        public async Task<SessionDto> Handle(CreateCommand<SessionCreateRequest, SessionDto, Session, long> request, CancellationToken cancellationToken)
        {
            // dto转实体，赋默认值
            var entity = _mapper.Map<Session>(request.Source);

            entity.PushNum = 0;
            entity.CreateTime = DateTime.Now;
            entity.State = CompleteState.Waiting;

            // 添加实体
            await _repository.AddAsync(entity);

            await _domainEventBus.PublishAsync(new CreatedEvent<Session>(entity));

            // 实体转dto
            return _mapper.Map<SessionDto>(entity);
        }
    }
}
