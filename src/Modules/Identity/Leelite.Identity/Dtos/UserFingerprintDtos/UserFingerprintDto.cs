using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintDto : IDto<long>
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string FingerName { get; set; }

        public string Fingerprint { get; set; }

        public bool IsEnabled { get; set; }

    }
}
