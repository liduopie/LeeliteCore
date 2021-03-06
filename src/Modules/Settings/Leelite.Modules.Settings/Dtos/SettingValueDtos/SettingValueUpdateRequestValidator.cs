﻿using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Settings.Dtos.SettingValueDtos
{
    public class SettingValueUpdateRequestValidator : Validator<SettingValueUpdateRequest>
    {
        public SettingValueUpdateRequestValidator()
        {
            RuleFor(c => c.Id.Name).NotNull();
        }
    }
}
