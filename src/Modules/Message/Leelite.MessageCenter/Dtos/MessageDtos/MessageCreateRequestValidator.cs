using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.MessageDtos
{
    public class MessageCreateRequestValidator : Validator<MessageCreateRequest>
    {
        public MessageCreateRequestValidator()
        {
        }
    }
}
