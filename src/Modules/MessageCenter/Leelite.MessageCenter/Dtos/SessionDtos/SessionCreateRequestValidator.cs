using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.MessageCenter.Dtos.SessionDtos
{
    public class SessionCreateRequestValidator : Validator<SessionCreateRequest>
    {
        public SessionCreateRequestValidator()
        {
        }
    }
}
