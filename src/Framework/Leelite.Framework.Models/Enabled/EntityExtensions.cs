namespace Leelite.Framework.Models.Enabled
{
    public static class EntityExtensions
    {
        /// <summary>
        /// 启用实体
        /// </summary>
        /// <param name="entity">实体</param>
        public static void Enabled(this IEnabled entity)
        {
            entity.IsEnabled = true;
        }

        /// <summary>
        /// 禁用实体
        /// </summary>
        /// <param name="entity">实体</param>
        public static void Disabled(this IEnabled entity)
        {
            entity.IsEnabled = false;
        }
    }
}
