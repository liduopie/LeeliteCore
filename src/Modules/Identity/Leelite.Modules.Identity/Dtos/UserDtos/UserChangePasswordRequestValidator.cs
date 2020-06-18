using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserDtos
{
    public class UserChangePasswordRequestValidator : Validator<UserChangePasswordRequest>
    {
        public UserChangePasswordRequestValidator()
        {
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
        }
    }
}
