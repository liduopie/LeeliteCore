using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service;
using Leelite.Modules.Settings.Dtos.SettingValueDtos;
using Leelite.Modules.Settings.Interfaces;
using Leelite.Modules.Settings.Models.SettingValueAgg;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Settings.Services
{
    public class SettingValueService : CrudService<SettingValue, SettingValueKey, SettingValueDto, SettingValueCreateRequest, SettingValueUpdateRequest, SettingValueQueryParameter>, ISettingValueService
    {
        public SettingValueService(
            IRepository<SettingValue, SettingValueKey> repository,
            ICommandBus commandBus,
            ILogger<SettingValueService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
