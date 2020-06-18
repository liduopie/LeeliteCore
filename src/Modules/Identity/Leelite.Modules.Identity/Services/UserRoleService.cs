using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserRoleDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserRoleAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class UserRoleService : CrudService<UserRole, UserRoleKey, UserRoleDto, UserRoleCreateRequest, UserRoleUpdateRequest, UserRoleQueryParameter>, IUserRoleService
    {
        public UserRoleService(
            IUserRoleRepository repository,
            ICommandBus commandBus,
            ILogger<UserRoleService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
