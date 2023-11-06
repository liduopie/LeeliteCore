using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Area.Models.AreaTypeAgg
{
    public class AreaType : AggregateRoot<string>
    {
        public string Name { get; set; }
    }
}
