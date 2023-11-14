namespace Leelite.Framework.Models.Tree
{
    public interface ITreeParameter<TKey>
    {
        /// <summary>
        /// 父标识
        /// </summary>
        TKey ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        int Level { get; set; }
    }
}
