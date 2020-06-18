using System;
using MediatR;

namespace Leelite.Framework.Domain.Event
{
    /// <summary>
    /// Defines interface for all Event data classes.
    /// </summary>
    public interface IDomainEvent<TSource> : IDomainEvent
    {
        /// <summary>
        /// The object which triggers the event (optional).
        /// </summary>
        TSource Source { get; set; }
    }

    public interface IDomainEvent : INotification
    {
        /// <summary>
        /// 事件Id
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The time when the event occured.
        /// </summary>
        DateTime EventTime { get; set; }
    }
}
