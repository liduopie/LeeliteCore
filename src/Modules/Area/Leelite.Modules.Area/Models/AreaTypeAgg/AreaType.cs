using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.Area.Models.AreaTypeAgg
{
    public class AreaType : AggregateRoot<string>
    {
        public string Name { get; set; }
    }
}
