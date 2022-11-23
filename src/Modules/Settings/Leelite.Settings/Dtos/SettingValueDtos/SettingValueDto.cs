using Leelite.Framework.Service.Dtos;
using Leelite.Settings.Models.SettingValueAgg;

namespace Leelite.Settings.Dtos.SettingValueDtos
{
    public class SettingValueDto : IDto<SettingValueKey>
    {
        public SettingValueKey Id { get; set; }
        public string Value { get; set; }
    }
}
