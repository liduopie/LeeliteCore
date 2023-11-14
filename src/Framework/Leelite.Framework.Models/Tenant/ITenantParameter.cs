namespace Leelite.Framework.Models.State
{
    public interface ITenantParameter<T>
    {
        /// <summary>
        /// 修改人标识
        /// </summary>
        T TenantId { get; set; }
    }
}
