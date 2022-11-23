using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Contexts;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;

namespace Leelite.Modules.MessageCenter.Repositories
{
    public interface IPushPlatformRepository : IRepository<PushPlatform, int>
    {
    }

    public class PushPlatformRepository : EFRepository<PushPlatform, int>, IPushPlatformRepository
    {
        public PushPlatformRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
