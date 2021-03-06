﻿using Leelite.Framework.Service;
using Leelite.Modules.Settings.Dtos.SettingValueDtos;
using Leelite.Modules.Settings.Models.SettingValueAgg;

namespace Leelite.Modules.Settings.Interfaces
{
    public interface ISettingValueService : ICrudService<SettingValue, SettingValueKey, SettingValueDto, SettingValueCreateRequest, SettingValueUpdateRequest, SettingValueQueryParameter>
    {
    }
}
