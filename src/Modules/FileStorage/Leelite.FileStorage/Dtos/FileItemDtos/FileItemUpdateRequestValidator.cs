using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.FileStorage.Dtos.FileItemDtos
{
    public class FileItemUpdateRequestValidator : Validator<FileItemUpdateRequest>
    {
        public FileItemUpdateRequestValidator()
        {
        }
    }
}
