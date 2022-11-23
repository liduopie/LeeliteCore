using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimUpdateRequestValidator : Validator<RoleClaimUpdateRequest>
    {
        public RoleClaimUpdateRequestValidator()
        {
        }
    }
}
