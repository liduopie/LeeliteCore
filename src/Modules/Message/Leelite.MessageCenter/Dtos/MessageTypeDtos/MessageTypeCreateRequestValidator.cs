using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.MessageTypeDtos
{
    public class MessageTypeCreateRequestValidator : Validator<MessageTypeCreateRequest>
    {
        public MessageTypeCreateRequestValidator()
        {
        }
    }
}
