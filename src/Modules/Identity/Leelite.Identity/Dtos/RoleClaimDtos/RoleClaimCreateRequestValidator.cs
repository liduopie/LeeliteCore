using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimCreateRequestValidator : Validator<RoleClaimCreateRequest>
    {
        public RoleClaimCreateRequestValidator()
        {
        }
    }
}
