using System;

using Leelite.Framework.Service.Dtos;
using Leelite.Modules.FileStorage.Models.FileItemAgg;

namespace Leelite.Modules.FileStorage.Dtos.FileItemDtos
{
    public class FileItemDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        public long TenantId { get; set; }

        public string ModuleCode { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string ContentType { get; set; }

        public string Size { get; set; }

        public long Length { get; set; }

        public string Path { get; set; }

        public byte[] Content { get; set; }

        public string MD5 { get; set; }

        public long CreatorId { get; set; }

        public string Creator { get; set; }

        public DateTime? CreationTime { get; set; }

        public long LastModifierId { get; set; }

        public string Modifier { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public FileState State { get; set; }

        public bool IsDeleted { get; set; }

        public long Visits { get; set; }

        public DateTime? LastVisitTime { get; set; }

    }
}
