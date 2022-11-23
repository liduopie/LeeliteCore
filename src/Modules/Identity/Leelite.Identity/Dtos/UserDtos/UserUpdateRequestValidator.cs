using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserDtos
{
    public class UserUpdateRequestValidator : Validator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
        }
    }
}
