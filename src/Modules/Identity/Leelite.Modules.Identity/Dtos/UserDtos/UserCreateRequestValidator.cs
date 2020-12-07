using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserDtos
{
    public class UserCreateRequestValidator : Validator<UserCreateRequest>
    {
        public UserCreateRequestValidator()
        {
        }
    }
}
