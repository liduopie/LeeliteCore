using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Identity.Contexts;
using Leelite.Identity.Models.UserFingerprintAgg;

namespace Leelite.Identity.Repositories
{
    public interface IUserFingerprintRepository : IRepository<UserFingerprint, long>
    {
    }

    public class UserFingerprintRepository : EFRepository<UserFingerprint, long>, IUserFingerprintRepository
    {
        public UserFingerprintRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
