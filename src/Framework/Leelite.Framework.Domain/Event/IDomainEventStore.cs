using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leelite.Framework.Domain.Event
{
    /// <summary>
    /// 定义事件存储接口，事件总线通过该接口将事件保存到存储。
    /// 并可以通过事件Id进行还原事件信息。
    /// </summary>
    public interface IDomainEventStore
    {
        /// <summary>
        /// Saves the event.
        /// </summary>
        /// <param name="event">Event.</param>
        /// <typeparam name="TAggregate">The 1st type parameter.</typeparam>
        void SaveEvent<TAggregate>(IDomainEvent @event);

        /// <summary>
        /// Gets the events async.
        /// </summary>
        /// <returns>The events async.</returns>
        /// <param name="aggregateId">Aggregate identifier.</param>
        Task<IDomainEvent> GetEventsAsync(Guid aggregateId);
    }
}
