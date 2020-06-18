using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserTokenDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserTokenAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class UserTokenService : CrudService<UserToken, UserTokenKey, UserTokenDto, UserTokenCreateRequest, UserTokenUpdateRequest, UserTokenQueryParameter>, IUserTokenService
    {
        public UserTokenService(
            IUserTokenRepository repository,
            ICommandBus commandBus,
            ILogger<UserTokenService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
