namespace Leelite.Framework.Models.Tenant
{
    /// <summary>
    /// 租户
    /// </summary>
    public interface ITenant<T>
    {
        /// <summary>
        /// 租户编号
        /// </summary>
        T TenantId { get; set; }
    }
}
