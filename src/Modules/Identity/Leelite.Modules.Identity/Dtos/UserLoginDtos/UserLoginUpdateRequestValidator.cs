using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserLoginDtos
{
    public class UserLoginUpdateRequestValidator : Validator<UserLoginUpdateRequest>
    {
        public UserLoginUpdateRequestValidator()
        {
        }
    }
}
