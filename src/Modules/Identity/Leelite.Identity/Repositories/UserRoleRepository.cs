using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Identity.Contexts;
using Leelite.Identity.Models.UserRoleAgg;

namespace Leelite.Identity.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole, UserRoleKey>
    {
    }

    public class UserRoleRepository : EFRepository<UserRole, UserRoleKey>, IUserRoleRepository
    {
        public UserRoleRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
