using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.UserKeyDtos
{
    public class UserKeyCreateRequest : IRequest
    {
        public string KeyId { get; set; }

        public string PublicKey { get; set; }

        public string SignatureRule { get; set; }

        public string SignatureData { get; set; }

    }
}
