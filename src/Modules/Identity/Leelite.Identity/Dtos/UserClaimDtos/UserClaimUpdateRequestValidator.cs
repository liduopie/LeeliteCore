using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserClaimDtos
{
    public class UserClaimUpdateRequestValidator : Validator<UserClaimUpdateRequest>
    {
        public UserClaimUpdateRequestValidator()
        {
        }
    }
}
