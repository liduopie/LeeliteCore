using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
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
