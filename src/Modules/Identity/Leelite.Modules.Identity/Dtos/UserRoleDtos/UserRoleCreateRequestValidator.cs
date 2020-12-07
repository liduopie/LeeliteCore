using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserRoleDtos
{
    public class UserRoleCreateRequestValidator : Validator<UserRoleCreateRequest>
    {
        public UserRoleCreateRequestValidator()
        {
        }
    }
}
