using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Message.Dtos.MessageDtos
{
    public class MessageUpdateRequestValidator : Validator<MessageUpdateRequest>
    {
        public MessageUpdateRequestValidator()
        {
        }
    }
}
