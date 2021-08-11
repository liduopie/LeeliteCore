using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.PushRecordDtos
{
    public class PushRecordUpdateRequestValidator : Validator<PushRecordUpdateRequest>
    {
        public PushRecordUpdateRequestValidator()
        {
        }
    }
}
