using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Identity.Contexts;
using Leelite.Identity.Models.UserTokenAgg;

namespace Leelite.Identity.Repositories
{
    public interface IUserTokenRepository : IRepository<UserToken, UserTokenKey>
    {
    }

    public class UserTokenRepository : EFRepository<UserToken, UserTokenKey>, IUserTokenRepository
    {
        public UserTokenRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
