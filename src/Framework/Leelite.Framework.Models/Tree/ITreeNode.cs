namespace Leelite.Framework.Models.Tree
{
    public interface ITreeNode<TKey, TSource>
    {
        public TKey Id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 父标识
        /// </summary>
        TKey ParentId { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        int Level { get; set; }

        /// <summary>
        /// 是叶子节点
        /// </summary>
        bool IsLeaf { get; set; }

        /// <summary>
        /// 子节点数量
        /// </summary>
        int ChildrenCount { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        TSource Source { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        IList<ITreeNode<TKey, TSource>> Children { get; set; }
    }
}
