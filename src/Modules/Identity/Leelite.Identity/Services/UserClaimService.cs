using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Identity.Dtos.UserClaimDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserClaimAgg;
using Leelite.Identity.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Identity.Services
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
