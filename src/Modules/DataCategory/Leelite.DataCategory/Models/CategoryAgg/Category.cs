using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Audit;
using Leelite.Framework.Models.Enabled;
using Leelite.Framework.Models.SoftDelete;
using Leelite.Framework.Models.Tree;

namespace Leelite.DataCategory.Models.CategoryAgg
{
    /// <summary>
    /// 数据分类
    /// </summary>
    public class Category : AggregateRoot<long>,
        ITree<long>,
        IAudit<long>,
        IEnabled,
        ISoftDelete
    {
        public int CategoryTypeId { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region ITree
        /// <inheritdoc/>
        public long ParentId { get; set; }

        /// <inheritdoc/>
        public string Path { get; set; }

        /// <inheritdoc/>
        public int Level { get; set; }

        /// <inheritdoc/>
        public int Sort { get; set; }

        /// <inheritdoc/>
        public bool IsLeaf { get; set; }

        /// <inheritdoc/>
        public int ChildrenCount { get; set; }
        #endregion

        #region IAudit

        /// <inheritdoc/>
        public long CreatorId { get; set; }

        /// <inheritdoc/>
        public string Creator { get; set; }

        /// <inheritdoc/>
        public DateTime? CreationTime { get; set; }

        /// <inheritdoc/>
        public long LastModifierId { get; set; }

        /// <inheritdoc/>
        public string Modifier { get; set; }

        /// <inheritdoc/>
        public DateTime? LastModificationTime { get; set; }

        #endregion

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }

        /// <inheritdoc/>
        public bool IsDeleted { get; set; }
    }
}
