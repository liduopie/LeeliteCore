using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.SessionDtos
{
    public class SessionCreateRequestValidator : Validator<SessionCreateRequest>
    {
        public SessionCreateRequestValidator()
        {
        }
    }
}
