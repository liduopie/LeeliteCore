using System.Collections;
using System.Collections.Generic;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Organization.Models.OrganizationTypeAgg
{
    /// <summary>
    /// 组织机构类型
    /// </summary>
    public class OrganizationType : AggregateRoot<string>
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 选项
        /// </summary>
        public OrganizationTypeOptions Options { get; set; }

        /// <summary>
        /// 该类型组织结构的属性定义集合
        /// </summary>
        public virtual IList<OrganizationTypeAttrDef> Attributes { get; set; }
    }
}
