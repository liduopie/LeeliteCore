using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.RoleClaimDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.RoleClaimAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class RoleClaimService : CrudService<RoleClaim, int, RoleClaimDto, RoleClaimCreateRequest, RoleClaimUpdateRequest, RoleClaimQueryParameter>, IRoleClaimService
    {
        public RoleClaimService(
            IRoleClaimRepository repository,
            ICommandBus commandBus,
            ILogger<RoleClaimService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
