using Leelite.Framework.Domain.Command;

namespace Leelite.Framework.Service.Commands
{
    public class UpdateCommand<TUpdateRequest, TDto, TEntity, TKey> : Command<TUpdateRequest, TDto>
    {
        public UpdateCommand(TUpdateRequest source) : base(source) { }
    }
}
