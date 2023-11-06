namespace Leelite.Organization.Models.OrganizationTreeAgg
{
    public class OrganizationTreeOptions
    {
        /// <summary>
        /// 组成树的组织机构类型
        /// </summary>
        public string NodeType { get; set; }

        /// <summary>
        /// 根节点
        /// </summary>
        public long RootId { get; set; }
    }
}
