using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.Identity.Dtos.UserKeyDtos
{
    public class UserKeyUpdateRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }

        public string KeyId { get; set; }

        public string PublicKey { get; set; }

        public string SignatureRule { get; set; }

        public string SignatureData { get; set; }

    }
}
