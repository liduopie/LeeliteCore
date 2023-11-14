namespace Leelite.Framework.Models.Enabled
{
    public interface ISoftDeletionAuditedParameter<TUserKey>
    {
        TUserKey DeleterId { get; set; }
    }
}
