using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintCreateRequestValidator : Validator<UserFingerprintCreateRequest>
    {
        public UserFingerprintCreateRequestValidator()
        {
        }
    }
}
