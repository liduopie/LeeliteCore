namespace Leelite.Framework.Service.Interfaces
{
    /// <summary>
    /// 删除操作
    /// </summary>
    public interface IDelete<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">标识</param>
        void Delete(TKey id);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        void Delete(TKey[] ids);
    }
}
