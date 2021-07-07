using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Message.Dtos.SessionDtos
{
    public class SessionCreateRequestValidator : Validator<SessionCreateRequest>
    {
        public SessionCreateRequestValidator()
        {
        }
    }
}
