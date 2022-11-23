using AutoMapper;
using Leelite.Settings.Dtos.SettingValueDtos;
using Leelite.Settings.Models.SettingValueAgg;

namespace Leelite.Settings
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
