using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Identity.Contexts;
using Leelite.Identity.Models.UserKeyAgg;

namespace Leelite.Identity.Repositories
{
    public interface IUserKeyRepository : IRepository<UserKey, long>
    {
    }

    public class UserKeyRepository : EFRepository<UserKey, long>, IUserKeyRepository
    {
        public UserKeyRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
