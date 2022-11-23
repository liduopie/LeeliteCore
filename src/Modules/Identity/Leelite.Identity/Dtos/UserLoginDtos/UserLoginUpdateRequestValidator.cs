using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserLoginDtos
{
    public class UserLoginUpdateRequestValidator : Validator<UserLoginUpdateRequest>
    {
        public UserLoginUpdateRequestValidator()
        {
        }
    }
}
