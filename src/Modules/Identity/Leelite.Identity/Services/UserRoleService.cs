using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserRoleDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserRoleAgg;
using Leelite.Identity.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
{
    public class UserRoleService : CrudService<UserRole, UserRoleKey, UserRoleDto, UserRoleCreateRequest, UserRoleUpdateRequest, UserRoleQueryParameter>, IUserRoleService
    {
        public UserRoleService(
            IUserRoleRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<UserRoleService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
