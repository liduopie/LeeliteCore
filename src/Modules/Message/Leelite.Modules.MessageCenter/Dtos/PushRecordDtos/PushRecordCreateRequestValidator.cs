using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.MessageCenter.Models.PushRecordAgg.Dtos.PushRecordDtos
{
    public class PushRecordCreateRequestValidator : Validator<PushRecordCreateRequest>
    {
        public PushRecordCreateRequestValidator()
        {
        }
    }
}
