using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.FileStorage.Dtos.FileItemDtos
{
    public class FileItemCreateRequestValidator : Validator<FileItemCreateRequest>
    {
        public FileItemCreateRequestValidator()
        {
        }
    }
}
