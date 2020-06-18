using System.Threading;
using System.Threading.Tasks;

namespace Leelite.Framework.Domain.Event
{
    /// <summary>
    /// Defines interface of the event bus.
    /// </summary>
    public interface IDomainEventBus
    {
        /// <summary>
        /// Publish the specified event.
        /// </summary>
        /// <returns>The publish.</returns>
        /// <param name="event">Event.</param>
        /// <typeparam name="TEvent">The 1st type parameter.</typeparam>
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IDomainEvent;

        /// <summary>
        /// Subscribe the specified event and handler.
        /// </summary>
        /// <returns>The subscribe.</returns>
        /// <param name="event">Event.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TEvent">The 1st type parameter.</typeparam>
        void Subscribe<TEvent>(TEvent @event, IDomainEventHandler<IDomainEvent> handler) where TEvent : IDomainEvent;
    }
}
