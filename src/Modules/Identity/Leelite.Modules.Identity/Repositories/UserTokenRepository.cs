using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.UserTokenAgg;

namespace Leelite.Modules.Identity.Repositories
{
    public interface IUserTokenRepository : IRepository<UserToken, UserTokenKey>
    {
    }

    public class UserTokenRepository : EFRepository<UserToken, UserTokenKey>, IUserTokenRepository
    {
        public UserTokenRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
