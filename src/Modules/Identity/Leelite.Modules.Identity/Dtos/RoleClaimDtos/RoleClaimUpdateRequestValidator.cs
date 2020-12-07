using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimUpdateRequestValidator : Validator<RoleClaimUpdateRequest>
    {
        public RoleClaimUpdateRequestValidator()
        {
        }
    }
}
