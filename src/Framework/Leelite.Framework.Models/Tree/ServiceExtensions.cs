﻿using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service;

namespace Leelite.Framework.Models.Tree
{
    /// <summary>
    /// 应用服务扩展
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 通过根节点获取树
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="rootId">根节点Id</param>
        /// <returns>根节点</returns>
        public static ITreeNode<TKey> GetTree<TEntity, TKey>(this IService<TEntity, TKey> service, TKey rootId)
            where TEntity : IAggregateRoot<TKey>, ITree<TKey>
            where TKey : IEquatable<TKey>
        {
            var rootEntity = service.Repository.FindById(rootId);

            if (rootEntity == null)
            {
                return new TreeNode<TKey>();
            }

            var rootNode = new TreeNode<TKey>()
            {
                Id = rootEntity.Id,
                ParentId = rootEntity.ParentId,
                Level = rootEntity.Level,
                Path = rootEntity.Path,
                Name = rootEntity.Name,
                Sort = rootEntity.Sort,
            };

            var allNode = service.Repository.Find(c => c.Path.StartsWith(rootEntity.Path));

            return BuildChildrenNode(allNode, rootNode);
        }

        /// <summary>
        /// 通过根节点获取树
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="service">应用服务</param>
        /// <param name="rootId">根节点Id</param>
        /// <returns>根节点</returns>
        public static async Task<ITreeNode<TKey>> GetTreeAsync<TEntity, TKey>(this IService<TEntity, TKey> service, TKey rootId)
            where TEntity : IAggregateRoot<TKey>, ITree<TKey>
            where TKey : IEquatable<TKey>
        {
            var rootEntity = await service.Repository.FindByIdAsync(rootId);

            if (rootEntity == null)
            {
                return new TreeNode<TKey>();
            }

            var rootNode = new TreeNode<TKey>()
            {
                Id = rootEntity.Id,
                ParentId = rootEntity.ParentId,
                Level = rootEntity.Level,
                Path = rootEntity.Path,
                Name = rootEntity.Name,
                Sort = rootEntity.Sort,
            };

            var allNode = await service.Repository.FindAsync(c => c.Path.StartsWith(rootEntity.Path));

            return BuildChildrenNode(allNode, rootNode);
        }

        /// <summary>
        /// 构建子节点
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="entities">所有节点</param>
        /// <param name="currentNode">当前节点</param>
        /// <returns>当前节点</returns>
        private static ITreeNode<TKey> BuildChildrenNode<TEntity, TKey>(IList<TEntity> entities, ITreeNode<TKey> currentNode)
            where TEntity : IAggregateRoot<TKey>, ITree<TKey>
            where TKey : IEquatable<TKey>
        {
            var children = entities.Where(c => c.ParentId.Equals(currentNode.Id)).OrderBy(c => c.Sort).ToList();

            var nodes = new List<ITreeNode<TKey>>();

            foreach (var item in children)
            {
                var node = new TreeNode<TKey>()
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                    Level = item.Level,
                    Path = item.Path,
                    Name = item.Name,
                    Sort = item.Sort,
                };

                BuildChildrenNode(entities, node);
                node.ChildrenCount = node.Children.Count;
                node.IsLeaf = node.ChildrenCount == 0;

                nodes.Add(node);
            }

            currentNode.Children = nodes;

            return currentNode;
        }
    }
}
