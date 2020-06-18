using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.UserRoleAgg;

namespace Leelite.Modules.Identity.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole, UserRoleKey>
    {
    }

    public class UserRoleRepository : EFRepository<UserRole, UserRoleKey>, IUserRoleRepository
    {
        public UserRoleRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
