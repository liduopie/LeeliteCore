using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.RoleClaimAgg;

namespace Leelite.Modules.Identity.Repositories
{
    public interface IRoleClaimRepository : IRepository<RoleClaim, int>
    {
    }

    public class RoleClaimRepository : EFRepository<RoleClaim, int>, IRoleClaimRepository
    {
        public RoleClaimRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
