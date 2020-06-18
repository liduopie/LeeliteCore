using MediatR;

namespace Leelite.Framework.Domain.Event
{
    /// <summary>
    /// Defines an interface of a class that handles events of type <see cref="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">Event type to handle</typeparam>
    public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
    {
    }
}
