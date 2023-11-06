using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Authorization.Models.PermissionRoleAgg
{
    public class PermissionRole : AggregateRoot<long>
    {
        public long OrganizationId { get; set; }
        public string Name { get; set; }
    }
}
