namespace Leelite.Framework.Models.SoftDelete
{
    public static class EntityExtensions
    {
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public static void Delete(this ISoftDelete entity)
        {
            entity.IsDeleted = true;
        }

        /// <summary>
        /// 恢复实体
        /// </summary>
        /// <param name="entity">实体</param>
        public static void Recover(this ISoftDelete entity)
        {
            entity.IsDeleted = false;
        }
    }
}
