using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Contexts;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Models.PushRecordAgg;

namespace Leelite.Modules.MessageCenter.Models.PushRecordAgg.Repositories
{
    public interface IPushRecordRepository : IRepository<PushRecord, long>
    {
    }

    public class PushRecordRepository : EFRepository<PushRecord, long>, IPushRecordRepository
    {
        public PushRecordRepository(PushRecordAggContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
