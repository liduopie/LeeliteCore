using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Tree;

namespace Leelite.Modules.Area.Models.AreaAgg
{
    public class Area : AggregateRoot<int>, ITree<int>
    {
        public int ParentId { get; set; }
        public string Path { get; set; }
        public int Level { get; set; }
        public int? SortId { get; set; }
        public int Sort { get; set; }
        public bool IsLeaf { get; set; }
        public int ChildrenCount { get; set; }
    }
}
