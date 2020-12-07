using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.RoleDtos
{
    public class RoleCreateRequestValidator : Validator<RoleCreateRequest>
    {
        public RoleCreateRequestValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
