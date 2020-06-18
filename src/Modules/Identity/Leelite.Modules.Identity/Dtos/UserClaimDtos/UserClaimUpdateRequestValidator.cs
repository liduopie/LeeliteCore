using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserClaimDtos
{
    public class UserClaimUpdateRequestValidator : Validator<UserClaimUpdateRequest>
    {
        public UserClaimUpdateRequestValidator()
        {
        }
    }
}
