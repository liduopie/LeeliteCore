using Leelite.Framework.Domain.Model;
using Leelite.Framework.Models.Sort;

namespace Leelite.Framework.Models.Tree
{
    /// <summary>
    /// 树型实体
    /// </summary>
    public interface ITree<TKey> : IEntity<TKey>, ISort
        where TKey : IEquatable<TKey>
    {
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
    }
}
