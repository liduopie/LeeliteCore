using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimCreateRequestValidator : Validator<RoleClaimCreateRequest>
    {
        public RoleClaimCreateRequestValidator()
        {
        }
    }
}
