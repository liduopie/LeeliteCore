using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserLoginDtos
{
    public class UserLoginCreateRequestValidator : Validator<UserLoginCreateRequest>
    {
        public UserLoginCreateRequestValidator()
        {
        }
    }
}
