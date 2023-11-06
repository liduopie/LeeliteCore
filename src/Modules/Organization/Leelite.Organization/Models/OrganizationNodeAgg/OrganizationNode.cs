using Leelite.Framework.Domain.Model;
using Leelite.Framework.Models.Tree;

namespace Leelite.Organization.Models.OrganizationNodeAgg
{
    public class OrganizationNode : Entity<long>, ITree<long>
    {
        public string TreeId { get; set; }

        /// <inheritdoc/>
        public long ParentId { get; set; }

        /// <inheritdoc/>
        public string Path { get; set; }

        /// <inheritdoc/>
        public int Level { get; set; }

        /// <inheritdoc/>
        public int? SortId { get; set; }

        /// <inheritdoc/>
        public int Sort { get; set; }

        /// <inheritdoc/>
        public bool IsLeaf { get; set; }

        /// <inheritdoc/>
        public int ChildrenCount { get; set; }
    }
}
