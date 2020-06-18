using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimUpdateRequestValidator : Validator<RoleClaimUpdateRequest>
    {
        public RoleClaimUpdateRequestValidator()
        {
        }
    }
}
