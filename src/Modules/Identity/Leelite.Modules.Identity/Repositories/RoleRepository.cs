using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.RoleAgg;

namespace Leelite.Modules.Identity.Repositories
{
    public interface IRoleRepository : IRepository<Role, int>
    {
    }

    public class RoleRepository : EFRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
