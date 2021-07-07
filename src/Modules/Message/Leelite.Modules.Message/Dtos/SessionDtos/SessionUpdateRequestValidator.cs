using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Message.Dtos.SessionDtos
{
    public class SessionUpdateRequestValidator : Validator<SessionUpdateRequest>
    {
        public SessionUpdateRequestValidator()
        {
        }
    }
}
