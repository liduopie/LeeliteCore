using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Settings.Contexts;
using Leelite.Modules.Settings.Models.SettingValueAgg;

namespace Leelite.Modules.Settings.Repositories
{
    public interface ISettingValueRepository : IRepository<SettingValue, SettingValueKey>
    {
    }

    public class SettingValueRepository : EFRepository<SettingValue, SettingValueKey>, ISettingValueRepository
    {
        public SettingValueRepository(SettingsContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
