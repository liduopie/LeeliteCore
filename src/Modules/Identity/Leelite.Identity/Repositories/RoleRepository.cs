using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Identity.Contexts;
using Leelite.Identity.Models.RoleAgg;

namespace Leelite.Identity.Repositories
{
    public interface IRoleRepository : IRepository<Role, int>
    {
    }

    public class RoleRepository : EFRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
