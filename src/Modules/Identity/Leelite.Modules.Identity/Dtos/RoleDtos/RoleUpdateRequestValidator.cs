using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.RoleDtos
{
    public class RoleUpdateRequestValidator : Validator<RoleUpdateRequest>
    {
        public RoleUpdateRequestValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
