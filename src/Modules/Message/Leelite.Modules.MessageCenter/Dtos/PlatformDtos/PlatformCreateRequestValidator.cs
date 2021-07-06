using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.Dtos.PlatformDtos
{
    public class PlatformCreateRequestValidator : Validator<PlatformCreateRequest>
    {
        public PlatformCreateRequestValidator()
        {
        }
    }
}
