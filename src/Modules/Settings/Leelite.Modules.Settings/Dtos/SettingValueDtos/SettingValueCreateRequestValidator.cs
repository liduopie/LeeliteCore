using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Settings.Dtos.SettingValueDtos
{
    public class SettingValueCreateRequestValidator : Validator<SettingValueCreateRequest>
    {
        public SettingValueCreateRequestValidator()
        {
            RuleFor(c => c.Id.Name).NotNull();
        }
    }
}
