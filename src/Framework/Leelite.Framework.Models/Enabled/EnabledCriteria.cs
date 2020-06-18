using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.Framework.Models.Enabled
{
    public static class EnabledCriteria
    {
        /// <summary>
        /// 查寻启用实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>返回启用条件</returns>
        public static Criterion<TEntity> Enabled<TEntity>()
            where TEntity : IEnabled
        {
            return new DirectCriterion<TEntity>(c => c.IsEnabled == true);
        }

        /// <summary>
        /// 查寻禁用实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <returns>返回禁用条件</returns>
        public static Criterion<TEntity> Disabled<TEntity>()
            where TEntity : IEnabled
        {
            return new DirectCriterion<TEntity>(c => c.IsEnabled == false);
        }
    }
}
