using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.UserKeyDtos
{
    public class UserKeyDto : IDto<long>
    {
        public long Id { get; set; }

        public string KeyId { get; set; }

        public string PublicKey { get; set; }

        public string SignatureRule { get; set; }

        public string SignatureData { get; set; }

    }
}
