using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.SoftDelete;

namespace Leelite.DataDictionary.Models.DataItemAgg
{
    public class DataItem : AggregateRoot<int>, ISoftDelete
    {
        public string DataTypeId { get; set; }
        public long OrganizationId { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public int Sort { get; set; }
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }
    }
}
