using System.IO;
using System.Text.Json.Serialization;
using Leelite.Framework.Service.Dtos;

namespace Leelite.FileStorage.Dtos.FileItemDtos
{
    public class FileItemCreateRequest : IRequest
    {
        public long TenantId { get; set; }

        public string ModuleCode { get; set; } = "";

        public string Name { get; set; }

        public string ContentType { get; set; }

        public long Length { get; set; }

        public long CreatorId { get; set; }

        public string Creator { get; set; }

        [JsonIgnore]
        public Stream FileStream { get; set; }
    }
}
