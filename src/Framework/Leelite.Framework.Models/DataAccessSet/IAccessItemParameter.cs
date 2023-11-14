namespace Leelite.Framework.Models.DataAccessSet
{
    public interface IAccessItemParameter
    {
        /// <summary>
        /// 权限
        /// </summary>
        string Permission { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        string UserId { get; set; }

        /// <summary>
        /// 分组Id
        /// </summary>
        string GroupId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        string RoleId { get; set; }
    }
}
