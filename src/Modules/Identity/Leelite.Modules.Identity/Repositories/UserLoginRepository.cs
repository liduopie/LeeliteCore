using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.UserLoginAgg;

namespace Leelite.Modules.Identity.Repositories
{
    public interface IUserLoginRepository : IRepository<UserLogin, UserLoginKey>
    {
    }

    public class UserLoginRepository : EFRepository<UserLogin, UserLoginKey>, IUserLoginRepository
    {
        public UserLoginRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
