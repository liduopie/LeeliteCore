using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserTokenDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserTokenAgg;
using Leelite.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
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
