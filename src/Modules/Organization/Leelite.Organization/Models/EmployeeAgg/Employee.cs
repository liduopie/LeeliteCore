using System;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Audit;
using Leelite.Framework.Models.Enabled;
using Leelite.Framework.Models.SoftDelete;
using Leelite.Framework.Models.State;

namespace Leelite.Organization.Models.EmployeeAgg
{
    public class Employee : AggregateRoot<long>,
        IAudit<long>,
        IState<EmployeeState>,
        IEnabled,
        ISoftDelete
    {
        /// <summary>
        /// 组织Id
        /// </summary>
        public long OrganizationId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 员工状态
        /// </summary>
        public EmployeeState State { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime TermDate { get; set; }

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
    }
}
