using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Identity.Dtos.UserClaimDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserClaimAgg;
using Leelite.Modules.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Identity.Services
{
    public class UserClaimService : CrudService<UserClaim, long, UserClaimDto, UserClaimCreateRequest, UserClaimUpdateRequest, UserClaimQueryParameter>, IUserClaimService
    {
        public UserClaimService(
            IUserClaimRepository repository,
            ICommandBus commandBus,
            ILogger<UserClaimService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
