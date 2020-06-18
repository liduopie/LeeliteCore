using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.FileStorage.Dtos.FileItemDtos
{
    public class FileItemUpdateRequestValidator : Validator<FileItemUpdateRequest>
    {
        public FileItemUpdateRequestValidator()
        {
        }
    }
}
