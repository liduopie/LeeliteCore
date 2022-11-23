using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Models.SessionAgg
{
    public class SessionValidator : Validator<Session>
    {
        public SessionValidator()
        {
            RuleFor(Session => Session.Title).NotNull().MaximumLength(256);
            RuleFor(Session => Session.Description).MaximumLength(512);
        }
    }
}
