using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserKeyDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserKeyAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class UserKeyService : CrudService<UserKey, long, UserKeyDto, UserKeyCreateRequest, UserKeyUpdateRequest, UserKeyQueryParameter>, IUserKeyService
    {
        public UserKeyService(
            IUserKeyRepository repository,
            ICommandBus commandBus,
            ILogger<UserKeyService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
