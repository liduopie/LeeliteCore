using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserLoginDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserLoginAgg;
using Leelite.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
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
