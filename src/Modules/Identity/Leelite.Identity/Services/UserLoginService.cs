using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
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
            IUnitOfWork unitOfWork,
            ILogger<UserLoginService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
