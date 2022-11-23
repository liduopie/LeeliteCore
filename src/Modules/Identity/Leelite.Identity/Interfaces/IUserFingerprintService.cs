using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserFingerprintDtos;
using Leelite.Identity.Models.UserFingerprintAgg;

namespace Leelite.Identity.Interfaces
{
    public interface IUserFingerprintService : ICrudService<UserFingerprint, long, UserFingerprintDto, UserFingerprintCreateRequest, UserFingerprintUpdateRequest, UserFingerprintQueryParameter>
    {
    }
}
