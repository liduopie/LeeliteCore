using System;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Audit;
using Leelite.Framework.Models.SoftDelete;
using Leelite.Framework.Models.State;
using Leelite.Framework.Models.Tenant;

namespace Leelite.Modules.FileStorage.Models.FileItemAgg
{
    public class FileItem : AggregateRoot<Guid>,
        ITenant<long>,
        IAudit<long>,
        IState<FileState>,
        ISoftDelete
    {
        /// <inheritdoc/>
        public long TenantId { get; set; }

        /// <summary>
        /// 模块代码
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 内容长度
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// MD5
        /// </summary>
        public string MD5 { get; set; }

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

        /// <summary>
        /// 文件状态
        /// </summary>
        public FileState State { get; set; }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        public long Visits { get; set; }

        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime? LastVisitTime { get; set; }
    }
}
