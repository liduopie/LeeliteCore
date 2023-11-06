using System;
using System.Collections.Generic;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Audit;
using Leelite.Framework.Models.Enabled;
using Leelite.Framework.Models.SoftDelete;
using Leelite.Framework.Models.Tenant;

namespace Leelite.Organization.Models.OrganizationAgg
{
    public class Organization : AggregateRoot<long>,
        ITenant<long>,
        IAudit<long>,
        IEnabled,
        ISoftDelete
    {
        /// <inheritdoc/>
        public long TenantId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }

        /// <inheritdoc/>
        public bool IsDeleted { get; set; }

        #region IAudit

        /// <inheritdoc/>
        public long CreatorId { get; set; }

        /// <inheritdoc/>
        public string Creator { get; set; }

        /// <inheritdoc/>
        public DateTime? CreationTime { get; set; }

        /// <inheritdoc/>
        public long LastModifierId { get; set; }

        /// <inheritdoc/>
        public string Modifier { get; set; }

        /// <inheritdoc/>
        public DateTime? LastModificationTime { get; set; }


        #endregion

        public virtual IList<OrganizationAttributes> Attributes { get; set; }
    }
}
