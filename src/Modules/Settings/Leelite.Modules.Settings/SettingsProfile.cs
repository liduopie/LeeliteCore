using AutoMapper;
using Leelite.Modules.Settings.Dtos.SettingValueDtos;
using Leelite.Modules.Settings.Models.SettingValueAgg;

namespace Leelite.Modules.Settings
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<SettingValue, SettingValueDto>();
            CreateMap<SettingValueCreateRequest, SettingValue>();
            CreateMap<SettingValueUpdateRequest, SettingValue>();
        }
    }
}
