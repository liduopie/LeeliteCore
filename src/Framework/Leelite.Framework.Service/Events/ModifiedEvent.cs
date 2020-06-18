using Leelite.Framework.Domain.Event;

namespace Leelite.Framework.Service.Events
{
    public class ModifiedEvent<TEntity> : DomainEvent<TEntity>
    {
        public ModifiedEvent(TEntity entity) : base(entity) { }
    }
}
