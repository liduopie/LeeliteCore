using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.RoleClaimDtos
{
    public class RoleClaimCreateRequestValidator : Validator<RoleClaimCreateRequest>
    {
        public RoleClaimCreateRequestValidator()
        {
        }
    }
}
