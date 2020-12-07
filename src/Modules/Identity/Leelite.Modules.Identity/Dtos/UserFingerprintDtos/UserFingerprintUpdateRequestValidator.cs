using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintUpdateRequestValidator : Validator<UserFingerprintUpdateRequest>
    {
        public UserFingerprintUpdateRequestValidator()
        {
        }
    }
}
