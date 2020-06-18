using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.DataDictionary.Models.DataTypeAgg
{
    public class DataType : AggregateRoot<string>
    {
        public string Name { get; set; }
        public TypeCategory Type { get; set; }
    }
}
