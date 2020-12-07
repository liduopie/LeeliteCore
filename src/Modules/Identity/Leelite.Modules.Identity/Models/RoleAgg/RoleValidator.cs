using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Models.RoleAgg
{
    public class RoleValidator : Validator<Role>
    {
        public RoleValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
