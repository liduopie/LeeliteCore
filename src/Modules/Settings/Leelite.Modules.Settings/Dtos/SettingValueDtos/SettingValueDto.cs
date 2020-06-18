using Leelite.Framework.Service.Dtos;
using Leelite.Modules.Settings.Models.SettingValueAgg;

namespace Leelite.Modules.Settings.Dtos.SettingValueDtos
{
    public class SettingValueDto : IDto<SettingValueKey>
    {
        public SettingValueKey Id { get; set; }
        public string Value { get; set; }
    }
}
