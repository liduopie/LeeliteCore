using FluentValidation;
using Leelite.Commons.Validation;

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
