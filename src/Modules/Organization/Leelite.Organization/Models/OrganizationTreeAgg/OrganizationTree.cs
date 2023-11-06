using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Organization.Models.OrganizationTreeAgg
{
    public class OrganizationTree : AggregateRoot<string>
    {
        /// <summary>
        /// 树状结构名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 树结构选项
        /// </summary>
        public OrganizationTreeOptions Options { get; set; }
    }
}
