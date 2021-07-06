using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Message.Models.MessageAgg.Dtos.MessageDtos
{
    public class MessageUpdateRequestValidator : Validator<MessageUpdateRequest>
    {
        public MessageUpdateRequestValidator()
        {
        }
    }
}
