using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserKeyDtos
{
    public class UserKeyCreateRequestValidator : Validator<UserKeyCreateRequest>
    {
        public UserKeyCreateRequestValidator()
        {
        }
    }
}
