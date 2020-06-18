using System.Collections.Generic;
using Leelite.Framework.Domain.Model;

namespace Leelite.Modules.Organization.Models.OrganizationTagAgg
{
    public class OrganizationTag : ValueObject<OrganizationTag>
    {
        /// <summary>
        /// 组织机构分类Id
        /// </summary>
        public string OrganizationTypeId { get; set; }

        /// <summary>
        /// 组织机构Id
        /// </summary>
        public long OrganizationId { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { OrganizationTypeId, OrganizationId };
        }
    }
}
