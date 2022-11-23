using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Identity.Contexts;
using Leelite.Identity.Models.UserLoginAgg;

namespace Leelite.Identity.Repositories
{
    public interface IUserLoginRepository : IRepository<UserLogin, UserLoginKey>
    {
    }

    public class UserLoginRepository : EFRepository<UserLogin, UserLoginKey>, IUserLoginRepository
    {
        public UserLoginRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
