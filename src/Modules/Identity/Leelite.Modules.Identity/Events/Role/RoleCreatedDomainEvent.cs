using Leelite.Framework.Domain.Event;

namespace Leelite.Modules.Identity.Events.Role
{
    using Leelite.Modules.Identity.Models.RoleAgg;

    public class RoleCreatedDomainEvent : DomainEvent<Role>
    {
        public RoleCreatedDomainEvent(Role source) : base(source) { }
    }
}
