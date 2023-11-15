using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.DataDictionary.Models.DataTypeAgg
{
    public class DataTypeValidator : Validator<DataType>
    {
        public DataTypeValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
