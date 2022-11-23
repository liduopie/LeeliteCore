using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.FileStorage.Dtos.FileItemDtos
{
    public class FileItemUpdateRequestValidator : Validator<FileItemUpdateRequest>
    {
        public FileItemUpdateRequestValidator()
        {
        }
    }
}
