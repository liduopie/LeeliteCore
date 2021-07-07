using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.PlatformDtos
{
    public class PlatformUpdateRequestValidator : Validator<PlatformUpdateRequest>
    {
        public PlatformUpdateRequestValidator()
        {
        }
    }
}
