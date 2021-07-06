using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.Dtos.PlatformDtos
{
    public class PlatformUpdateRequestValidator : Validator<PlatformUpdateRequest>
    {
        public PlatformUpdateRequestValidator()
        {
        }
    }
}
