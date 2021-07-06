using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Message.Models.MessageTypeAgg.Dtos.MessageTypeDtos
{
    public class MessageTypeUpdateRequestValidator : Validator<MessageTypeUpdateRequest>
    {
        public MessageTypeUpdateRequestValidator()
        {
        }
    }
}
