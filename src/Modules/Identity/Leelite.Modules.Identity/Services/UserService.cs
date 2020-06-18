using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class UserService : CrudService<User, long, UserDto, UserCreateRequest, UserUpdateRequest, UserQueryParameter>, IUserService
    {
        public UserService(
            IUserRepository repository,
            ICommandBus commandBus,
            ILogger<UserService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
