using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.RoleDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.RoleAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class RoleService : CrudService<Role, int, RoleDto, RoleCreateRequest, RoleUpdateRequest, RoleQueryParameter>, IRoleService
    {
        public RoleService(
            IRoleRepository repository,
            ICommandBus commandBus,
            ILogger<RoleService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
