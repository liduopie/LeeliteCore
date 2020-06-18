using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Identity.Contexts;
using Leelite.Modules.Identity.Models.UserFingerprintAgg;

namespace Leelite.Modules.Identity.Repositories
{
    public interface IUserFingerprintRepository : IRepository<UserFingerprint, long>
    {
    }

    public class UserFingerprintRepository : EFRepository<UserFingerprint, long>, IUserFingerprintRepository
    {
        public UserFingerprintRepository(IdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
