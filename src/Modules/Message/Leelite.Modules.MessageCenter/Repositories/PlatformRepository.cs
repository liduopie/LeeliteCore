using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Contexts;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Models.PlatformAgg;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.Repositories
{
    public interface IPlatformRepository : IRepository<Platform, long>
    {
    }

    public class PlatformRepository : EFRepository<Platform, long>, IPlatformRepository
    {
        public PlatformRepository(PlatformAggContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
