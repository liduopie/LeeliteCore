using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.MessageCenter.Dtos.SessionDtos
{
    public class SessionUpdateRequestValidator : Validator<SessionUpdateRequest>
    {
        public SessionUpdateRequestValidator()
        {
        }
    }
}
