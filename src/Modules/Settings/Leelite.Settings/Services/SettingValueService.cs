using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;
using Leelite.Settings.Dtos.SettingValueDtos;
using Leelite.Settings.Interfaces;
using Leelite.Settings.Models.SettingValueAgg;

using Microsoft.Extensions.Logging;

namespace Leelite.Settings.Services
{
    public class SettingValueService : CrudService<SettingValue, SettingValueKey, SettingValueDto, SettingValueCreateRequest, SettingValueUpdateRequest, SettingValueQueryParameter>, ISettingValueService
    {
        public SettingValueService(
            IRepository<SettingValue, SettingValueKey> repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<SettingValueService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
