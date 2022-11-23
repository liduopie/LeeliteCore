using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintUpdateRequestValidator : Validator<UserFingerprintUpdateRequest>
    {
        public UserFingerprintUpdateRequestValidator()
        {
        }
    }
}
