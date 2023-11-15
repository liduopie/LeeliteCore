namespace Leelite.Framework.Models.Tree
{
    public interface ITreeNode<TKey> : ITree<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 子节点
        /// </summary>
        IList<ITreeNode<TKey>> Children { get; set; }
    }
}
