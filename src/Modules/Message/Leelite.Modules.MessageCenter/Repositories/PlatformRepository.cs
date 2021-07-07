using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Contexts;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;

namespace Leelite.Modules.MessageCenter.Repositories
{
    public interface IPlatformRepository : IRepository<Platform, long>
    {
    }

    public class PlatformRepository : EFRepository<Platform, long>, IPlatformRepository
    {
        public PlatformRepository(MessageCenterContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
