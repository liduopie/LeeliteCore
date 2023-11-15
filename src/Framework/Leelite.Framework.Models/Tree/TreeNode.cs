using Leelite.Framework.Domain.Model;

namespace Leelite.Framework.Models.Tree
{
    public class TreeNode<TKey> : Entity<TKey>, ITreeNode<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; }
        public TKey ParentId { get; set; }
        public string Path { get; set; }
        public int Level { get; set; }
        public bool IsLeaf { get; set; }
        public int ChildrenCount { get; set; }
        public int Sort { get; set; }
        public IList<ITreeNode<TKey>> Children { get; set; }
    }
}
