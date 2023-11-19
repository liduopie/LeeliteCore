using MediatR;

namespace Leelite.Framework.Domain.Event
{
    public class DomainEventBus : IDomainEventBus
    {
        private readonly IMediator _mediator;

        public DomainEventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IDomainEvent
        {
            await _mediator.Publish(@event);
        }

        public void Subscribe<TEvent>(TEvent @event, IDomainEventHandler<IDomainEvent> handler) where TEvent : IDomainEvent
        {

        }
    }
}
