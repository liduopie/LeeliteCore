using FluentValidation;
using Leelite.Commons.Validation;

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
