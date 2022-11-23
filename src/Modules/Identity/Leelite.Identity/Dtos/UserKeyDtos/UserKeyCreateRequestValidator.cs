using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserKeyDtos
{
    public class UserKeyCreateRequestValidator : Validator<UserKeyCreateRequest>
    {
        public UserKeyCreateRequestValidator()
        {
        }
    }
}
