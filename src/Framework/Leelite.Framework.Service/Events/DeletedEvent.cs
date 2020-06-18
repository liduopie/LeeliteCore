using Leelite.Framework.Domain.Event;

namespace Leelite.Framework.Service.Events
{
    public class DeletedEvent<TEntity> : DomainEvent<TEntity>
    {
        public DeletedEvent(TEntity entity) : base(entity) { }

    }
}
