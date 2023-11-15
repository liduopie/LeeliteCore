using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.DataDictionary.Models.DataItemAgg
{
    public class DataItemValidator : Validator<DataItem>
    {
        public DataItemValidator()
        {
            RuleFor(c => c.Value).NotNull();
        }
    }
}
