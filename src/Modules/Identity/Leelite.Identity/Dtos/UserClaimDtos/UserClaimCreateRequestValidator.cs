using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserClaimDtos
{
    public class UserClaimCreateRequestValidator : Validator<UserClaimCreateRequest>
    {
        public UserClaimCreateRequestValidator()
        {
        }
    }
}
