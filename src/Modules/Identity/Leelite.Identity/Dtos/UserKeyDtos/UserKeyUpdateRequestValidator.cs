using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserKeyDtos
{
    public class UserKeyUpdateRequestValidator : Validator<UserKeyUpdateRequest>
    {
        public UserKeyUpdateRequestValidator()
        {
        }
    }
}
