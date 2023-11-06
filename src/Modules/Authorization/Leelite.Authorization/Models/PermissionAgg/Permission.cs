using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Tree;

namespace Leelite.Authorization.Models.PermissionAgg
{
    public class Permission : AggregateRoot<string>, ITree<string>
    {
        public string Name { get; set; }
        public string Exclusions { get; set; }
        public string ParentId { get; set; }
        public string Path { get; set; }
        public int Level { get; set; }
        public int? SortId { get; set; }
        public int Sort { get; set; }
        public bool IsLeaf { get; set; }
        public int ChildrenCount { get; set; }
    }
}
