using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.MessageCenter.Dtos.PushRecordDtos
{
    public class PushRecordUpdateRequestValidator : Validator<PushRecordUpdateRequest>
    {
        public PushRecordUpdateRequestValidator()
        {
        }
    }
}
