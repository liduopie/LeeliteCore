using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Models.Tree
{
    public static class TreeCriteria
    {
        /// <summary>
        /// 查询子节点
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="parentId">父节点Id</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> Children<TEntity, TKey>(TKey parentId)
            where TEntity : ITree<TKey>
            where TKey : IEquatable<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.ParentId.Equals(parentId));
        }

        /// <summary>
        /// 查询子节点
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="level">级别</param>
        /// <returns>返回条件</returns>
        public static Criterion<TEntity> Level<TEntity, TKey>(int level)
            where TEntity : ITree<TKey>
            where TKey : IEquatable<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.Level == level);
        }

        /// <summary>
        /// 根据路径查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Criterion<TEntity> Path<TEntity, TKey>(string path)
            where TEntity : ITree<TKey>
            where TKey : IEquatable<TKey>
        {
            return new DirectCriterion<TEntity>(c => c.Path.StartsWith(path));
        }
    }
}
