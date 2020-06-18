using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.UserClaimAgg;

namespace Leelite.Modules.Identity.Repositories
{
    public interface IUserClaimRepository : IRepository<UserClaim, long>
    {
    }

    public class UserClaimRepository : EFRepository<UserClaim, long>, IUserClaimRepository
    {
        public UserClaimRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
