using System;
using Leelite.Framework.Domain.Model;

namespace Leelite.Organization.Models.OrganizationTypeAgg
{
    /// <summary>
    /// 组织结构类型的属性定义
    /// </summary>
    public class OrganizationTypeAttrDef : Entity<OrganizationTypeAttrDefKey>
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// 必填项
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }

    public class OrganizationTypeAttrDefKey : IEquatable<OrganizationTypeAttrDefKey>
    {
        /// <summary>
        /// 类型Id
        /// </summary>
        public string TypeId { get; set; }

        /// <summary>
        /// 属性代码
        /// </summary>
        public string Code { get; set; }

        public bool Equals(OrganizationTypeAttrDefKey other)
        {
            return TypeId == other.TypeId && Code == other.Code;
        }
    }

    public enum DataType
    {
        Int,
        String,
    }
}
