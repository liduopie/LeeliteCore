using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.RoleClaimDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.RoleClaimAgg;
using Leelite.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
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
