using System;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.Area.Models.AreaOrganizationAgg
{
    public class AreaOrganization : AggregateRoot<AreaOrganizationKey>
    {
    }

    public class AreaOrganizationKey : IEquatable<AreaOrganizationKey>
    {
        public string RelationCode { get; set; }

        public int AreaId { get; set; }

        public int OrganizationId { get; set; }

        public bool Equals(AreaOrganizationKey other)
        {
            return RelationCode == other.RelationCode &&
                AreaId == other.AreaId &&
                OrganizationId == other.OrganizationId;
        }
    }
}
