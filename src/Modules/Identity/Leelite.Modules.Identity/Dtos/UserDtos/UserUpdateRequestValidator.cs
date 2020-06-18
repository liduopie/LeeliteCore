using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserDtos
{
    public class UserUpdateRequestValidator : Validator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
        }
    }
}
