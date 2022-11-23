using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserRoleDtos
{
    public class UserRoleCreateRequestValidator : Validator<UserRoleCreateRequest>
    {
        public UserRoleCreateRequestValidator()
        {
        }
    }
}
