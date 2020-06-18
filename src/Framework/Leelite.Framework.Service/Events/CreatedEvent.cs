using Leelite.Framework.Domain.Event;

namespace Leelite.Framework.Service.Events
{
    public class CreatedEvent<TEntity> : DomainEvent<TEntity>
    {
        public CreatedEvent(TEntity entity) : base(entity) { }
    }
}
