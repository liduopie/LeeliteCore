using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.PlatformDtos
{
    public class PlatformCreateRequestValidator : Validator<PlatformCreateRequest>
    {
        public PlatformCreateRequestValidator()
        {
        }
    }
}
