using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.MessageCenter.Dtos.MessageDtos
{
    public class MessageUpdateRequestValidator : Validator<MessageUpdateRequest>
    {
        public MessageUpdateRequestValidator()
        {
        }
    }
}
