using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserRoleDtos
{
    public class UserRoleUpdateRequestValidator : Validator<UserRoleUpdateRequest>
    {
        public UserRoleUpdateRequestValidator()
        {
        }
    }
}
