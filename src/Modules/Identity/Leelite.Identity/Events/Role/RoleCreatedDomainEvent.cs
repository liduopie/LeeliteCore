using Leelite.Framework.Domain.Event;

namespace Leelite.Identity.Events.Role
{
    using Leelite.Identity.Models.RoleAgg;

    public class RoleCreatedDomainEvent : DomainEvent<Role>
    {
        public RoleCreatedDomainEvent(Role source) : base(source) { }
    }
}
