using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.MessageTypeDtos
{
    public class MessageTypeUpdateRequestValidator : Validator<MessageTypeUpdateRequest>
    {
        public MessageTypeUpdateRequestValidator()
        {
        }
    }
}