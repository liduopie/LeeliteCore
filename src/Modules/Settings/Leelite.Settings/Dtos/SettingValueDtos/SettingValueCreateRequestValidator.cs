using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Settings.Dtos.SettingValueDtos
{
    public class SettingValueCreateRequestValidator : Validator<SettingValueCreateRequest>
    {
        public SettingValueCreateRequestValidator()
        {
            RuleFor(c => c.Id.Name).NotNull();
        }
    }
}
