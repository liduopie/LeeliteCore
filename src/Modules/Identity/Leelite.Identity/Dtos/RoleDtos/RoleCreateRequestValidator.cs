using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.RoleDtos
{
    public class RoleCreateRequestValidator : Validator<RoleCreateRequest>
    {
        public RoleCreateRequestValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
