using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserLoginDtos
{
    public class UserLoginUpdateRequestValidator : Validator<UserLoginUpdateRequest>
    {
        public UserLoginUpdateRequestValidator()
        {
        }
    }
}
