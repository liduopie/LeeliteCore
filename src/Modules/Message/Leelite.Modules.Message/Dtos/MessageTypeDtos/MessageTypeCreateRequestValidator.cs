using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Message.Dtos.MessageTypeDtos
{
    public class MessageTypeCreateRequestValidator : Validator<MessageTypeCreateRequest>
    {
        public MessageTypeCreateRequestValidator()
        {
        }
    }
}
