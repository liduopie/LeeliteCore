using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserFingerprintDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserFingerprintAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class UserFingerprintService : CrudService<UserFingerprint, long, UserFingerprintDto, UserFingerprintCreateRequest, UserFingerprintUpdateRequest, UserFingerprintQueryParameter>, IUserFingerprintService
    {
        public UserFingerprintService(
            IUserFingerprintRepository repository,
            ICommandBus commandBus,
            ILogger<UserFingerprintService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
