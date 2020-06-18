using System;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.Area.Models.AreaEmployeeAgg
{
    public class AreaEmployee : AggregateRoot<AreaEmployeeKey>
    {
    }

    public class AreaEmployeeKey : IEquatable<AreaEmployeeKey>
    {
        public string RelationCode { get; set; }

        public int AreaId { get; set; }

        public long EmployeeId { get; set; }

        public bool Equals(AreaEmployeeKey other)
        {
            return RelationCode == other.RelationCode &&
                AreaId == other.AreaId &&
                EmployeeId == other.EmployeeId;
        }
    }
}
