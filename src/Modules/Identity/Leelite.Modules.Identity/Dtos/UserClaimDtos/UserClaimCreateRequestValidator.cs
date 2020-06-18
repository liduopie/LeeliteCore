using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserClaimDtos
{
    public class UserClaimCreateRequestValidator : Validator<UserClaimCreateRequest>
    {
        public UserClaimCreateRequestValidator()
        {
        }
    }
}
