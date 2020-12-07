using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserFingerprintDtos
{
    public class UserFingerprintCreateRequestValidator : Validator<UserFingerprintCreateRequest>
    {
        public UserFingerprintCreateRequestValidator()
        {
        }
    }
}
