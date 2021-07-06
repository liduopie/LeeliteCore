using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Message.Dtos.MessageDtos
{
    public class MessageCreateRequestValidator : Validator<MessageCreateRequest>
    {
        public MessageCreateRequestValidator()
        {
        }
    }
}
