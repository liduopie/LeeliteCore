using System;
using System.Collections.Generic;
using System.Text;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.Authorization.Models.PermissionRoleAgg
{
    public class PermissionRole : AggregateRoot<long>
    {
        public long OrganizationId { get; set; }
        public string Name { get; set; }
    }
}
