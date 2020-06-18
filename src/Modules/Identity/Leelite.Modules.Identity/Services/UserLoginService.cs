using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserLoginDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserLoginAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class UserLoginService : CrudService<UserLogin, UserLoginKey, UserLoginDto, UserLoginCreateRequest, UserLoginUpdateRequest, UserLoginQueryParameter>, IUserLoginService
    {
        public UserLoginService(
            IUserLoginRepository repository,
            ICommandBus commandBus,
            ILogger<UserLoginService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
