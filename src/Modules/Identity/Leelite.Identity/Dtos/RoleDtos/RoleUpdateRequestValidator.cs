using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.RoleDtos
{
    public class RoleUpdateRequestValidator : Validator<RoleUpdateRequest>
    {
        public RoleUpdateRequestValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
