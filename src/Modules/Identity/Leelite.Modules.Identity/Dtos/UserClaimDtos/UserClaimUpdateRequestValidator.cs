using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserClaimDtos
{
    public class UserClaimUpdateRequestValidator : Validator<UserClaimUpdateRequest>
    {
        public UserClaimUpdateRequestValidator()
        {
        }
    }
}
