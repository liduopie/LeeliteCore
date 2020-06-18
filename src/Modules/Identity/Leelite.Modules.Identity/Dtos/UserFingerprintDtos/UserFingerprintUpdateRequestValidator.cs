using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintUpdateRequestValidator : Validator<UserFingerprintUpdateRequest>
    {
        public UserFingerprintUpdateRequestValidator()
        {
        }
    }
}
