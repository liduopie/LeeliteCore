using System;

namespace Leelite.Framework.Domain.Event
{
    public abstract class DomainEvent<TSource> : DomainEvent, IDomainEvent<TSource>
    {
        public DomainEvent(TSource source) : base()
        {
            Source = source;
        }

        public TSource Source { get; set; }
    }

    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            Id = Guid.NewGuid();
            EventTime = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime EventTime { get; set; }
    }
}
