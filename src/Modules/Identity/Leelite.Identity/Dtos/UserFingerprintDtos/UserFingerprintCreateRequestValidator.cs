using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintCreateRequestValidator : Validator<UserFingerprintCreateRequest>
    {
        public UserFingerprintCreateRequestValidator()
        {
        }
    }
}
