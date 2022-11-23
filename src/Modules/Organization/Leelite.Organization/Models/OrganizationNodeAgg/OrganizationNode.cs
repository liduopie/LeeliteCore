using Leelite.Framework.Domain.Model;
using Leelite.Framework.Models.Tree;

namespace Leelite.Modules.Organization.Models.OrganizationNodeAgg
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
    }
}
