﻿namespace Leelite.Framework.Models.Tree
{
    /// <summary>
    /// 树型实体
    /// </summary>
    public interface ITree<TKey>
    {
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
        /// 排序号
        /// </summary>
        int? SortId { get; set; }
    }
}
