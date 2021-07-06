using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Message.Models.MessageTypeAgg.Dtos.MessageTypeDtos
{
    public class MessageTypeCreateRequestValidator : Validator<MessageTypeCreateRequest>
    {
        public MessageTypeCreateRequestValidator()
        {
        }
    }
}
