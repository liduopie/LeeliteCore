using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.UserAgg;

namespace Leelite.Modules.Identity.Repositories
{
    public interface IUserRepository : IRepository<User, long>
    {
    }

    public class UserRepository : EFRepository<User, long>, IUserRepository
    {
        public UserRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
