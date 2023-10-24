using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.MessageCenter.Dtos.MessageTypeDtos
{
    public class MessageTypeCreateRequestValidator : Validator<MessageTypeCreateRequest>
    {
        public MessageTypeCreateRequestValidator()
        {
        }
    }
}
