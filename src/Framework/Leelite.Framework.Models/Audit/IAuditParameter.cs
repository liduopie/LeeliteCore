namespace Leelite.Framework.Models.Enabled
{
    public interface IAuditParameter<TKey>
    {
        TKey CreatorId { get; set; }
        TKey LastModifierId { get; set; }
    }
}
