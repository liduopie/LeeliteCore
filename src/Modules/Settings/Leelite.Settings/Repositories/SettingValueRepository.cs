using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Settings.Contexts;
using Leelite.Settings.Models.SettingValueAgg;

namespace Leelite.Settings.Repositories
{
    public interface ISettingValueRepository : IRepository<SettingValue, SettingValueKey>
    {
    }

    public class SettingValueRepository : EFRepository<SettingValue, SettingValueKey>, ISettingValueRepository
    {
        public SettingValueRepository(SettingsContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
