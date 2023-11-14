namespace Leelite.Framework.Models.Audit
{
    public static class EntityExtensions
    {
        /// <summary>
        /// 添加创建人
        /// </summary>
        /// <typeparam name="TUserKey">用户主键类型</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="creatorId">创建人Id</param>
        /// <param name="creator">创建人名称</param>
        public static void AddCreator<TUserKey>(this ICreationAudited<TUserKey> entity, TUserKey creatorId, string creator)
        {
            entity.CreatorId = creatorId;
            entity.Creator = creator;
            entity.CreationTime = DateTime.Now;
        }

        /// <summary>
        /// 添加修改人
        /// </summary>
        /// <typeparam name="TUserKey">用户主键类型</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="modifierId">修改人Id</param>
        /// <param name="modifier">修改人名称</param>
        public static void AddModifier<TUserKey>(this IModificationAudited<TUserKey> entity, TUserKey modifierId, string modifier)
        {
            entity.LastModifierId = modifierId;
            entity.Modifier = modifier;
            entity.LastModificationTime = DateTime.Now;
        }

        /// <summary>
        /// 添加软删除人
        /// </summary>
        /// <typeparam name="TUserKey">用户主键类型</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="deleterId">删除人Id</param>
        /// <param name="deleter">删除人名称</param>
        public static void AddDeleter<TUserKey>(this ISoftDeletionAudited<TUserKey> entity, TUserKey deleterId, string deleter)
        {
            entity.DeleterId = deleterId;
            entity.Deleter = deleter;
            entity.DeletionTime = DateTime.Now;
        }
    }
}
