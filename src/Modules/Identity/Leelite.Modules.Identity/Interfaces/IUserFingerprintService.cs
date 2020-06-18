using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserFingerprintDtos;
using Leelite.Modules.Identity.Models.UserFingerprintAgg;

namespace Leelite.Modules.Identity.Interfaces
{
    public interface IUserFingerprintService : ICrudService<UserFingerprint, long, UserFingerprintDto, UserFingerprintCreateRequest, UserFingerprintUpdateRequest, UserFingerprintQueryParameter>
    {
    }
}
