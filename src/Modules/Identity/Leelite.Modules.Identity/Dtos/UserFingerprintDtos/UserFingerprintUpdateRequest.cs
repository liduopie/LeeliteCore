using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintUpdateRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string FingerName { get; set; }

        public string Fingerprint { get; set; }

        public bool IsEnabled { get; set; }

    }
}
