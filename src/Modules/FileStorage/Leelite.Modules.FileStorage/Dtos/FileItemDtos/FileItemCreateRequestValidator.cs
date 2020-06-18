using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.FileStorage.Dtos.FileItemDtos
{
    public class FileItemCreateRequestValidator : Validator<FileItemCreateRequest>
    {
        public FileItemCreateRequestValidator()
        {
        }
    }
}
