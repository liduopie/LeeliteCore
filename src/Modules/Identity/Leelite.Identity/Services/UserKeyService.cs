using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserKeyDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserKeyAgg;
using Leelite.Identity.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
{
    public class UserKeyService : CrudService<UserKey, long, UserKeyDto, UserKeyCreateRequest, UserKeyUpdateRequest, UserKeyQueryParameter>, IUserKeyService
    {
        public UserKeyService(
            IUserKeyRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<UserKeyService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
