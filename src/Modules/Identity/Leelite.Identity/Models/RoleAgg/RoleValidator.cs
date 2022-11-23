using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Models.RoleAgg
{
    public class RoleValidator : Validator<Role>
    {
        public RoleValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
