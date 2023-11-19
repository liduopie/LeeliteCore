namespace Leelite.Framework.Models.Tree
{
    public class TreeNode<TKey, TSource> : ITreeNode<TKey, TSource>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public TKey ParentId { get; set; }
        public string Path { get; set; }
        public int Level { get; set; }
        public bool IsLeaf { get; set; }
        public int ChildrenCount { get; set; }
        public int Sort { get; set; }
        public TSource Source { get; set; }
        public IList<ITreeNode<TKey, TSource>> Children { get; set; }
    }
}
