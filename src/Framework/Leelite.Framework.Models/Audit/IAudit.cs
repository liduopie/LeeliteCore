namespace Leelite.Framework.Models.Audit
{
    /// <summary>
    /// 操作审计
    /// </summary>
    public interface IAudit<TKey> : ICreationAudited<TKey>, IModificationAudited<TKey>
    {

    }
}
