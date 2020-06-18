using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintCreateRequest : IRequest
    {
        public long UserId { get; set; }

        public string FingerName { get; set; }

        public string Fingerprint { get; set; }

        public bool IsEnabled { get; set; }

    }
}
