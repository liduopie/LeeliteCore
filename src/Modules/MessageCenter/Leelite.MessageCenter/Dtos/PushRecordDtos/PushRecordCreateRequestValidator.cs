using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.MessageCenter.Dtos.PushRecordDtos
{
    public class PushRecordCreateRequestValidator : Validator<PushRecordCreateRequest>
    {
        public PushRecordCreateRequestValidator()
        {
        }
    }
}
