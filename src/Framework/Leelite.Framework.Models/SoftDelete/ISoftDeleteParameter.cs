namespace Leelite.Framework.Models.SoftDelete
{
    public interface ISoftDeleteParameter
    {
        bool? Deleted { get; set; }
    }
}
