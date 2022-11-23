using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserDtos
{
    public class UserCreateRequestValidator : Validator<UserCreateRequest>
    {
        public UserCreateRequestValidator()
        {
        }
    }
}
