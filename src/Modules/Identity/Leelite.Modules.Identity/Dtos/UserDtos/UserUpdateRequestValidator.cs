using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserDtos
{
    public class UserUpdateRequestValidator : Validator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
        }
    }
}
