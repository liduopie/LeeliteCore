using Leelite.Framework.Service;
using Leelite.Settings.Dtos.SettingValueDtos;
using Leelite.Settings.Models.SettingValueAgg;
using Leelite.Commons.Lifetime;

namespace Leelite.Settings.Interfaces
{
    public interface ISettingValueService : ICrudService<SettingValue, SettingValueKey, SettingValueDto, SettingValueCreateRequest, SettingValueUpdateRequest, SettingValueQueryParameter>
    {
    }
}
