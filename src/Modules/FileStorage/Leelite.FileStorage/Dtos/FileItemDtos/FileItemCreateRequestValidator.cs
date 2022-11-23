using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.FileStorage.Dtos.FileItemDtos
{
    public class FileItemCreateRequestValidator : Validator<FileItemCreateRequest>
    {
        public FileItemCreateRequestValidator()
        {
        }
    }
}
