using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.MessageCenter.Contexts;
using Leelite.MessageCenter.Models.PushPlatformAgg;

namespace Leelite.MessageCenter.Repositories
{
    public interface IPushPlatformRepository : IRepository<PushPlatform, int>
    {
    }

    public class PushPlatformRepository : EFRepository<PushPlatform, int>, IPushPlatformRepository
    {
        public PushPlatformRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
