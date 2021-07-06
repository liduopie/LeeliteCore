using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Message.Models.SessionAgg.Dtos.SessionDtos
{
    public class SessionCreateRequestValidator : Validator<SessionCreateRequest>
    {
        public SessionCreateRequestValidator()
        {
        }
    }
}
