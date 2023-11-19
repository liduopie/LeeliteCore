using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.RoleDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.RoleAgg;
using Leelite.Identity.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
{
    public class RoleService : CrudService<Role, int, RoleDto, RoleCreateRequest, RoleUpdateRequest, RoleQueryParameter>, IRoleService
    {
        public RoleService(
            IRoleRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<RoleService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
