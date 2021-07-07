using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Contexts;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;

namespace Leelite.Modules.MessageCenter.Repositories
{
    public interface IPushRecordRepository : IRepository<PushRecord, long>
    {
    }

    public class PushRecordRepository : EFRepository<PushRecord, long>, IPushRecordRepository
    {
        public PushRecordRepository(MessageCenterContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
