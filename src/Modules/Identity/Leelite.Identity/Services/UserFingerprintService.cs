using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserFingerprintDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserFingerprintAgg;
using Leelite.Identity.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
{
    public class UserFingerprintService : CrudService<UserFingerprint, long, UserFingerprintDto, UserFingerprintCreateRequest, UserFingerprintUpdateRequest, UserFingerprintQueryParameter>, IUserFingerprintService
    {
        public UserFingerprintService(
            IUserFingerprintRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<UserFingerprintService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
