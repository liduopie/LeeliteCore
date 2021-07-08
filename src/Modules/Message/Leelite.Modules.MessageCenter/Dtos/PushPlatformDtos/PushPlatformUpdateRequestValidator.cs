using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.PushPlatformDtos
{
    public class PushPlatformUpdateRequestValidator : Validator<PushPlatformUpdateRequest>
    {
        public PushPlatformUpdateRequestValidator()
        {
        }
    }
}
