using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.MessageCenter.Dtos.PushPlatformDtos
{
    public class PushPlatformCreateRequestValidator : Validator<PushPlatformCreateRequest>
    {
        public PushPlatformCreateRequestValidator()
        {
        }
    }
}
