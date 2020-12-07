using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserClaimDtos
{
    public class UserClaimCreateRequestValidator : Validator<UserClaimCreateRequest>
    {
        public UserClaimCreateRequestValidator()
        {
        }
    }
}
